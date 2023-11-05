using System;
using System.Collections.Generic;

namespace Aneta.Models;

public partial class TransactionSummary
{
    public int TransactionId { get; set; }

    public string? MunicipalityName { get; set; }

    public string? BarangayName { get; set; }

    public int ItemId { get; set; }

    public int? ItemDocumentId { get; set; }

    public string? UnitName { get; set; }

    public string? Particulars { get; set; }

    public int? Quantity { get; set; }

    public decimal? ItemAmount { get; set; }

    public decimal? ItemPrice { get; set; }

    public int? TransactionDocumentId { get; set; }

    public string? PunongBarangayName { get; set; }

    public string? BarangayTreasurerName { get; set; }

    public int DocumentId { get; set; }

    public int RequestId { get; set; }

    public int? RequestDocumentId { get; set; }

    public string? RequestNumber { get; set; }

    public string? Requisition { get; set; }

    public string? DeliveryLocation { get; set; }

    public DateTime? RequestDate { get; set; }

    public string? DeliveryTerms { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public string? RequestedByName { get; set; }

    public string? ApprovedForIssuanceName { get; set; }

    public string? Purpose { get; set; }

    public string? RequestorName { get; set; }

    public int? PurchaseOrderDocumentId { get; set; }

    public string? ModeOfProcurement { get; set; }

    public int OrderId { get; set; }

    public int AbstractId { get; set; }

    public int? AbstractDocumentId { get; set; }

    public DateTime? AbstractOpenDate { get; set; }

    public string? AbstractOfficeLocation { get; set; }

    public string? OfficeOfThe { get; set; }

    public string? AwardedToThe { get; set; }

    public string? OpeningQuotationsOffice { get; set; }

    public decimal? ItemCost { get; set; }
}
