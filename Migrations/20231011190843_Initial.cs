using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dsa_marketing.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MunicipalityName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BarangayName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transact__55433A6BB5BA0BB7", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionDocuments",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(type: "int", nullable: true),
                    PunongBarangayName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BarangayTreasurerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transact__1ABEEF0F895E8B39", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK__Transacti__Trans__6E01572D",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "TransactionId");
                });

            migrationBuilder.CreateTable(
                name: "AbstractQuotation",
                columns: table => new
                {
                    AbstractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    OpenDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OfficeLocation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OfficeOfThe = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AwardedToThe = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OpeningQuotationsOffice = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Abstract__467E99E828743250", x => x.AbstractId);
                    table.ForeignKey(
                        name: "FK__AbstractQ__Docum__76969D2E",
                        column: x => x.DocumentId,
                        principalTable: "TransactionDocuments",
                        principalColumn: "DocumentId");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    ModeOfProcurement = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Purchase__C3905BCF2225EE71", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK__PurchaseO__Docum__73BA3083",
                        column: x => x.DocumentId,
                        principalTable: "TransactionDocuments",
                        principalColumn: "DocumentId");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequest",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    RequestNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Requisition = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeliveryLocation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeliveryTerms = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Purpose = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RequestedByName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ApprovedForIssuanceName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RequestorName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Purchase__33A8517A0003AF50", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK__PurchaseR__Docum__70DDC3D8",
                        column: x => x.DocumentId,
                        principalTable: "TransactionDocuments",
                        principalColumn: "DocumentId");
                });

            migrationBuilder.CreateTable(
                name: "TransactionItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    UnitName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Particulars = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transact__727E838B52808D46", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK__Transacti__Docum__797309D9",
                        column: x => x.DocumentId,
                        principalTable: "TransactionDocuments",
                        principalColumn: "DocumentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbstractQuotation_DocumentId",
                table: "AbstractQuotation",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_DocumentId",
                table: "PurchaseOrder",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequest_DocumentId",
                table: "PurchaseRequest",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDocuments_TransactionId",
                table: "TransactionDocuments",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionItems_DocumentId",
                table: "TransactionItems",
                column: "DocumentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbstractQuotation");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "PurchaseRequest");

            migrationBuilder.DropTable(
                name: "TransactionItems");

            migrationBuilder.DropTable(
                name: "TransactionDocuments");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
