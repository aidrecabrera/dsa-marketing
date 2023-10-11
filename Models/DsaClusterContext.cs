using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dsa_marketing.Models;

public partial class DsaClusterContext : DbContext
{
    public DsaClusterContext()
    {
    }

    public DsaClusterContext(DbContextOptions<DsaClusterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AbstractQuotation> AbstractQuotations { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public virtual DbSet<PurchaseRequest> PurchaseRequests { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TransactionDocument> TransactionDocuments { get; set; }

    public virtual DbSet<TransactionItem> TransactionItems { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=WindowsPC\\SQLEXPRESS;Database=dsa_cluster;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AbstractQuotation>(entity =>
        {
            entity.HasKey(e => e.AbstractId).HasName("PK__Abstract__467E99E828743250");

            entity.ToTable("AbstractQuotation");

            entity.Property(e => e.AwardedToThe).HasMaxLength(255);
            entity.Property(e => e.OfficeLocation).HasMaxLength(255);
            entity.Property(e => e.OfficeOfThe).HasMaxLength(255);
            entity.Property(e => e.OpenDate).HasColumnType("datetime");
            entity.Property(e => e.OpeningQuotationsOffice).HasMaxLength(255);

            entity.HasOne(d => d.Document).WithMany(p => p.AbstractQuotations)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("FK__AbstractQ__Docum__76969D2E");
        });

        modelBuilder.Entity<PurchaseOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Purchase__C3905BCF2225EE71");

            entity.ToTable("PurchaseOrder");

            entity.Property(e => e.ModeOfProcurement).HasMaxLength(255);

            entity.HasOne(d => d.Document).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("FK__PurchaseO__Docum__73BA3083");
        });

        modelBuilder.Entity<PurchaseRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Purchase__33A8517A0003AF50");

            entity.ToTable("PurchaseRequest");

            entity.Property(e => e.ApprovedForIssuanceName).HasMaxLength(255);
            entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.DeliveryLocation).HasMaxLength(255);
            entity.Property(e => e.DeliveryTerms).HasMaxLength(255);
            entity.Property(e => e.Purpose).HasMaxLength(255);
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.RequestNumber).HasMaxLength(255);
            entity.Property(e => e.RequestedByName).HasMaxLength(255);
            entity.Property(e => e.RequestorName).HasMaxLength(255);
            entity.Property(e => e.Requisition).HasMaxLength(255);

            entity.HasOne(d => d.Document).WithMany(p => p.PurchaseRequests)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("FK__PurchaseR__Docum__70DDC3D8");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__55433A6BB5BA0BB7");

            entity.Property(e => e.BarangayName).HasMaxLength(255);
            entity.Property(e => e.MunicipalityName).HasMaxLength(255);
        });

        modelBuilder.Entity<TransactionDocument>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__Transact__1ABEEF0F895E8B39");

            entity.Property(e => e.BarangayTreasurerName).HasMaxLength(255);
            entity.Property(e => e.PunongBarangayName).HasMaxLength(255);

            entity.HasOne(d => d.Transaction).WithMany(p => p.TransactionDocuments)
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("FK__Transacti__Trans__6E01572D");
        });

        modelBuilder.Entity<TransactionItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Transact__727E838B52808D46");

            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Particulars).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UnitName).HasMaxLength(255);

            entity.HasOne(d => d.Document).WithMany(p => p.TransactionItems)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("FK__Transacti__Docum__797309D9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
