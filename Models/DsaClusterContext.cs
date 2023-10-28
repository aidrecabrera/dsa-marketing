using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Aneta.Models;

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

    public virtual DbSet<ExistingTransactionsSummary> ExistingTransactionsSummaries { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public virtual DbSet<PurchaseRequest> PurchaseRequests { get; set; }

    public virtual DbSet<Transactions> Transactions { get; set; }

    public virtual DbSet<TransactionDocument> TransactionDocuments { get; set; }

    public virtual DbSet<TransactionItem> TransactionItems { get; set; }

    public virtual DbSet<TransactionSummary> TransactionSummaries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=dsamarketing.database.windows.net,1433;Database=dsa_cluster;User Id=aidrecabrera;Password=Svene@MCM717;Encrypt=True;TrustServerCertificate=False;MultipleActiveResultSets=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AbstractQuotation>(entity =>
        {
            entity.HasKey(e => e.AbstractId).HasName("PK__Abstract__467E99E89C542D48");

            entity.ToTable("AbstractQuotation");

            entity.Property(e => e.AwardedToThe).HasMaxLength(255);
            entity.Property(e => e.OfficeLocation).HasMaxLength(255);
            entity.Property(e => e.OfficeOfThe).HasMaxLength(255);
            entity.Property(e => e.OpenDate).HasColumnType("datetime");
            entity.Property(e => e.OpeningQuotationsOffice).HasMaxLength(255);

            entity.HasOne(d => d.Document).WithMany(p => p.AbstractQuotations)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("FK__AbstractQ__Docum__5AB9788F");
        });

        modelBuilder.Entity<ExistingTransactionsSummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ExistingTransactionsSummary");

            entity.Property(e => e.BarangayName).HasMaxLength(255);
            entity.Property(e => e.BarangayTreasurerName).HasMaxLength(255);
            entity.Property(e => e.MunicipalityName).HasMaxLength(255);
            entity.Property(e => e.PunongBarangayName).HasMaxLength(255);
        });

        modelBuilder.Entity<PurchaseOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Purchase__C3905BCF4646B207");

            entity.ToTable("PurchaseOrder");

            entity.Property(e => e.ModeOfProcurement).HasMaxLength(255);

            entity.HasOne(d => d.Document).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("FK__PurchaseO__Docum__57DD0BE4");
        });

        modelBuilder.Entity<PurchaseRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Purchase__33A8517A09B6713B");

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
                .HasConstraintName("FK__PurchaseR__Docum__55009F39");
        });

        modelBuilder.Entity<Transactions>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__55433A6BDC0F81C6");

            entity.Property(e => e.BarangayName).HasMaxLength(255);
            entity.Property(e => e.MunicipalityName).HasMaxLength(255);
        });

        modelBuilder.Entity<TransactionDocument>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__Transact__1ABEEF0FE149BD41");

            entity.Property(e => e.BarangayTreasurerName).HasMaxLength(255);
            entity.Property(e => e.PunongBarangayName).HasMaxLength(255);

            entity.HasOne(d => d.Transaction).WithMany(p => p.TransactionDocuments)
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("FK__Transacti__Trans__5224328E");
        });

        modelBuilder.Entity<TransactionItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Transact__727E838BA7399CEF");

            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Particulars).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UnitName).HasMaxLength(255);

            entity.HasOne(d => d.Document).WithMany(p => p.TransactionItems)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("FK__Transacti__Docum__5D95E53A");
        });

        modelBuilder.Entity<TransactionSummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("TransactionSummary");

            entity.Property(e => e.AbstractOfficeLocation).HasMaxLength(255);
            entity.Property(e => e.AbstractOpenDate).HasColumnType("datetime");
            entity.Property(e => e.ApprovedForIssuanceName).HasMaxLength(255);
            entity.Property(e => e.AwardedToThe).HasMaxLength(255);
            entity.Property(e => e.BarangayName).HasMaxLength(255);
            entity.Property(e => e.BarangayTreasurerName).HasMaxLength(255);
            entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.DeliveryLocation).HasMaxLength(255);
            entity.Property(e => e.DeliveryTerms).HasMaxLength(255);
            entity.Property(e => e.ItemAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ItemCost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ItemPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ModeOfProcurement).HasMaxLength(255);
            entity.Property(e => e.MunicipalityName).HasMaxLength(255);
            entity.Property(e => e.OfficeOfThe).HasMaxLength(255);
            entity.Property(e => e.OpeningQuotationsOffice).HasMaxLength(255);
            entity.Property(e => e.Particulars).HasMaxLength(255);
            entity.Property(e => e.PunongBarangayName).HasMaxLength(255);
            entity.Property(e => e.Purpose).HasMaxLength(255);
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.RequestNumber).HasMaxLength(255);
            entity.Property(e => e.RequestedByName).HasMaxLength(255);
            entity.Property(e => e.RequestorName).HasMaxLength(255);
            entity.Property(e => e.Requisition).HasMaxLength(255);
            entity.Property(e => e.UnitName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
