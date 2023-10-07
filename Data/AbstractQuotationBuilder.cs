namespace dsa_marketing.Models
{
    public class AbstractQuotationBuilder : IAbstractQuotationBuilder
    {
        private AbstractQuotationModel _abstract = new AbstractQuotationModel();

        public AbstractQuotationBuilder WithAbstractId(int abstractId)
        {
            _abstract.AbstractId = abstractId;
            return this;
        }

        public AbstractQuotationBuilder WithDocumentId(int documentId)
        {
            _abstract.DocumentId = documentId;
            return this;
        }

        public AbstractQuotationBuilder WithOpenDate(DateTime openDate)
        {
            _abstract.OpenDate = openDate;
            return this;
        }

        public AbstractQuotationBuilder WithOfficeLocation(string officeLocation)
        {
            _abstract.OfficeLocation = officeLocation;
            return this;
        }

        public AbstractQuotationBuilder WithOfficeOfThe(string officeOfThe)
        {
            _abstract.OfficeOfThe = officeOfThe;
            return this;
        }

        public AbstractQuotationBuilder WithAwardedToThe(string awardedToThe)
        {
            _abstract.AwardedToThe = awardedToThe;
            return this;
        }

        public AbstractQuotationBuilder WithOpeningQuotationsOffice(string openingQuotationsOffice)
        {
            _abstract.OpeningQuotationsOffice = openingQuotationsOffice;
            return this;
        }

        public AbstractModel Build()
        {
            return _abstract;
        }
    }
}
