namespace dsa_marketing.Models
{
    public class TransactionDocumentsBuilder : ITransactionDocumentsBuilder
    {
        private TransactionDocumentsModel _document = new TransactionDocumentsModel();

        public TransactionDocumentsBuilder WithDocumentId(int documentId)
        {
            _document.DocumentId = documentId;
            return this;
        }

        public TransactionDocumentsBuilder WithTransactionId(int transactionId)
        {
            _document.TransactionId = transactionId;
            return this;
        }

        public TransactionDocumentsBuilder WithPunongBarangayName(string punongBarangayName)
        {
            _document.PunongBarangayName = punongBarangayName;
            return this;
        }

        public TransactionDocumentsBuilder WithBarangayTreasurerName(string barangayTreasurerName)
        {
            _document.BarangayTreasurerName = barangayTreasurerName;
            return this;
        }

        public TransactionDocumentsModel Build()
        {
            return _document;
        }
    }
}
