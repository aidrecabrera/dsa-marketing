using System;
using System.Collections.Generic;

namespace dsa_marketing.Models;

public partial class TransactionItem
{
    public int ItemId { get; set; }

    public int? DocumentId { get; set; }

    public string? UnitName { get; set; }

    public string? Particulars { get; set; }

    public int? Quantity { get; set; }

    public decimal? Cost { get; set; }

    public decimal? Amount { get; set; }

    public decimal? Price { get; set; }

    public virtual TransactionDocuments? Document { get; set; }
}
