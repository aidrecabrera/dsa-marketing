using System;
using System.Collections.Generic;

namespace dsa_marketing.Models;

public partial class TransactionDocuments
{
    public int DocumentId { get; set; }

    public int? TransactionId { get; set; }

    public string? PunongBarangayName { get; set; }

    public string? BarangayTreasurerName { get; set; }

    public virtual ICollection<AbstractQuotation> AbstractQuotations { get; set; } = new List<AbstractQuotation>();

    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();

    public virtual ICollection<PurchaseRequest> PurchaseRequests { get; set; } = new List<PurchaseRequest>();

    public virtual Transaction? Transaction { get; set; }

    public virtual ICollection<TransactionItem> TransactionItems { get; set; } = new List<TransactionItem>();
}
