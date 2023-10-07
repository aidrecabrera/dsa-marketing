using dsa_marketing.Models;
using System;

namespace dsa_marketing.Data
{
    public class TransactionsViewBuilder : ITransactionsViewBuilder
    {
        private TransactionViewModel _transaction = new TransactionViewModel();

        public TransactionViewModel Build()
        {
            return _transaction;
        }

        public ITransactionsViewBuilder SetWithTransactionId(int value)
        {
            _transaction.TransactionId = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithMunicipalityName(string value)
        {
            _transaction.MunicipalityName = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithBarangayName(string value)
        {
            _transaction.BarangayName = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithPunongBarangayName(string value)
        {
            _transaction.PunongBarangayName = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithBarangayTreasurerName(string value)
        {
            _transaction.BarangayTreasurerName = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithUnitName(string value)
        {
            _transaction.UnitName = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithParticulars(string value)
        {
            _transaction.Particulars = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithQuantity(int value)
        {
            _transaction.Quantity = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithCost(decimal value)
        {
            _transaction.Cost = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithAmount(decimal value)
        {
            _transaction.Amount = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithPrice(decimal value)
        {
            _transaction.Price = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithModeOfProcurement(string value)
        {
            _transaction.ModeOfProcurement = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithOpenDate(DateTime? value)
        {
            _transaction.OpenDate = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithOfficeLocation(string value)
        {
            _transaction.OfficeLocation = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithOfficeOfThe(string value)
        {
            _transaction.OfficeOfThe = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithAwardedToThe(string value)
        {
            _transaction.AwardedToThe = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithOpeningQuotationsOffice(string value)
        {
            _transaction.OpeningQuotationsOffice = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithRequestNumber(string value)
        {
            _transaction.RequestNumber = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithRequestDate(DateTime? value)
        {
            _transaction.RequestDate = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithRequisition(string value)
        {
            _transaction.Requisition = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithDeliveryLocation(string value)
        {
            _transaction.DeliveryLocation = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithDeliveryTerms(string value)
        {
            _transaction.DeliveryTerms = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithDeliveryDate(DateTime? value)
        {
            _transaction.DeliveryDate = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithPurpose(string value)
        {
            _transaction.Purpose = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithRequestedByName(string value)
        {
            _transaction.RequestedByName = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithApprovedForIssuanceName(string value)
        {
            _transaction.ApprovedForIssuanceName = value;
            return this;
        }

        public ITransactionsViewBuilder SetWithRequestorName(string value)
        {
            _transaction.RequestorName = value;
            return this;
        }
    }
}
