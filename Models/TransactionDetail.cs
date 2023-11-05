using System;
using System.Collections.Generic;

namespace Aneta.Models;

public partial class TransactionDetail
{
    public int TransactionId { get; set; }

    public string? MunicipalityName { get; set; }

    public string? BarangayName { get; set; }

    public virtual ICollection<TransactionDocument> TransactionDocuments { get; set; } = new List<TransactionDocument>();
}
