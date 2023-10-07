namespace dsa_marketing.Models
{
    public interface ITransactionDocumentsBuilder
    {
        TransactionDocumentsModel Build();
        TransactionDocumentsBuilder WithBarangayTreasurerName(string barangayTreasurerName);
        TransactionDocumentsBuilder WithDocumentId(int documentId);
        TransactionDocumentsBuilder WithPunongBarangayName(string punongBarangayName);
        TransactionDocumentsBuilder WithTransactionId(int transactionId);
    }
}