namespace dsa_marketing.Models;

public sealed class AbstractQuotation
{
    public int AbstractId { get; set; }

    public int? DocumentId { get; set; }

    public DateTime? OpenDate { get; set; }

    public string? OfficeLocation { get; set; }

    public string? OfficeOfThe { get; set; }

    public string? AwardedToThe { get; set; }

    public string? OpeningQuotationsOffice { get; set; }

    public TransactionDocuments? Document { get; set; }
}
