using dsa_marketing.Models;

namespace dsa_marketing.Data
{
    public class TransactionsBuilder : ITransactionsBuilder
    {
        private TransactionsModel transaction = new TransactionsModel();

        public TransactionsModel Build()
        {
            return transaction;
        }

        public ITransactionsBuilder SetWithTransactionId(int value)
        {
            transaction.TransactionId = value;
            return this;
        }

        public ITransactionsBuilder SetWithMunicipalityName(string value)
        {
            transaction.MunicipalityName = value;
            return this;
        }

        public ITransactionsBuilder SetWithBarangayName(string value)
        {
            transaction.BarangayName = value;
            return this;
        }

        public ITransactionsBuilder SetWithPunongBarangayName(string value)
        {
            transaction.PunongBarangayName = value;
            return this;
        }

        public ITransactionsBuilder SetWithBarangayTreasurerName(string value)
        {
            transaction.BarangayTreasurerName = value;
            return this;
        }

        public ITransactionsBuilder SetWithUnitName(List<string> value)
        {
            transaction.UnitName = value;
            return this;
        }

        public ITransactionsBuilder SetWithParticulars(List<string> value)
        {
            transaction.Particulars = value;
            return this;
        }

        public ITransactionsBuilder SetWithQuantity(List<int> value)
        {
            transaction.Quantity = value;
            return this;
        }

        public ITransactionsBuilder SetWithCost(List<decimal> value)
        {
            transaction.Cost = value;
            return this;
        }

        public ITransactionsBuilder SetWithAmount(List<decimal> value)
        {
            transaction.Amount = value;
            return this;
        }

        public ITransactionsBuilder SetWithPrice(decimal value)
        {
            transaction.Price = value;
            return this;
        }

        public ITransactionsBuilder SetWithModeOfProcurement(string value)
        {
            transaction.ModeOfProcurement = value;
            return this;
        }

        public ITransactionsBuilder SetWithOpenDate(DateTime value)
        {
            transaction.OpenDate = value;
            return this;
        }

        public ITransactionsBuilder SetWithOfficeLocation(string value)
        {
            transaction.OfficeLocation = value;
            return this;
        }

        public ITransactionsBuilder SetWithOfficeOfThe(string value)
        {
            transaction.OfficeOfThe = value;
            return this;
        }

        public ITransactionsBuilder SetWithAwardedToThe(string value)
        {
            transaction.AwardedToThe = value;
            return this;
        }

        public ITransactionsBuilder SetWithOpeningQuotationsOffice(string value)
        {
            transaction.OpeningQuotationsOffice = value;
            return this;
        }

        public ITransactionsBuilder SetWithRequestNumber(string value)
        {
            transaction.RequestNumber = value;
            return this;
        }

        public ITransactionsBuilder SetWithRequestDate(DateTime value)
        {
            transaction.RequestDate = value;
            return this;
        }

        public ITransactionsBuilder SetWithRequisition(string value)
        {
            transaction.Requisition = value;
            return this;
        }

        public ITransactionsBuilder SetWithDeliveryLocation(string value)
        {
            transaction.DeliveryLocation = value;
            return this;
        }

        public ITransactionsBuilder SetWithDeliveryTerms(string value)
        {
            transaction.DeliveryTerms = value;
            return this;
        }

        public ITransactionsBuilder SetWithDeliveryDate(DateTime value)
        {
            transaction.DeliveryDate = value;
            return this;
        }

        public ITransactionsBuilder SetWithPurpose(string value)
        {
            transaction.Purpose = value;
            return this;
        }

        public ITransactionsBuilder SetWithRequestedByName(string value)
        {
            transaction.RequestedByName = value;
            return this;
        }

        public ITransactionsBuilder SetWithApprovedForIssuanceName(string value)
        {
            transaction.ApprovedForIssuanceName = value;
            return this;
        }

        public ITransactionsBuilder SetWithRequestorName(string value)
        {
            transaction.RequestorName = value;
            return this;
        }
    }
}