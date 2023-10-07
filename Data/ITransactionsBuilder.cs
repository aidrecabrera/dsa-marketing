namespace dsa_marketing.Models
{
    public interface ITransactionsBuilder
    {
        TransactionsModel Build();
        TransactionsBuilder WithBarangayName(string barangayName);
        TransactionsBuilder WithMunicipalityName(string municipalityName);
        TransactionsBuilder WithTransactionId(int transactionId);
    }
}