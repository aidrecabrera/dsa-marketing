namespace dsa_marketing.Models
{
    public interface IAbstractQuotationBuilder
    {
        AbstractQuotationModel Build();
        AbstractQuotationBuilder WithAbstractId(int abstractId);
        AbstractQuotationBuilder WithAwardedToThe(string awardedToThe);
        AbstractQuotationBuilder WithDocumentId(int documentId);
        AbstractQuotationBuilder WithOfficeLocation(string officeLocation);
        AbstractQuotationBuilder WithOfficeOfThe(string officeOfThe);
        AbstractQuotationBuilder WithOpenDate(DateTime openDate);
        AbstractQuotationBuilder WithOpeningQuotationsOffice(string openingQuotationsOffice);
    }
}