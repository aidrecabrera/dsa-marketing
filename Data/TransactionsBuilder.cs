namespace dsa_marketing.Models
{
    public class TransactionsBuilder : ITransactionsBuilder
    {
        private TransactionsModel _transaction = new TransactionsModel();

        public TransactionsBuilder WithTransactionId(int transactionId)
        {
            _transaction.TransactionId = transactionId;
            return this;
        }

        public TransactionsBuilder WithMunicipalityName(string municipalityName)
        {
            _transaction.MunicipalityName = municipalityName;
            return this;
        }

        public TransactionsBuilder WithBarangayName(string barangayName)
        {
            _transaction.BarangayName = barangayName;
            return this;
        }

        public TransactionsModel Build()
        {
            return _transaction;
        }
    }
}
