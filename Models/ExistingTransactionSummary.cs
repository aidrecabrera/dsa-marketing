using System;
using System.Collections.Generic;

namespace Aneta.Models;

public partial class ExistingTransactionSummary
{
    public int TransactionId { get; set; }

    public string? MunicipalityName { get; set; }

    public string? BarangayName { get; set; }

    public int? TransactionDocumentId { get; set; }

    public string? PunongBarangayName { get; set; }

    public string? BarangayTreasurerName { get; set; }

    public int DocumentId { get; set; }
}
