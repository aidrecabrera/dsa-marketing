using System;
using System.Collections.Generic;

namespace dsa_marketing.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public string? MunicipalityName { get; set; }

    public string? BarangayName { get; set; }

    public virtual ICollection<TransactionDocuments> TransactionDocuments { get; set; } = new List<TransactionDocuments>();
}
