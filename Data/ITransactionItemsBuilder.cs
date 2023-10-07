namespace dsa_marketing.Models
{
    public interface ITransactionItemsBuilder
    {
        TransactionItemsModel Build();
        TransactionItemsBuilder WithAmount(decimal amount);
        TransactionItemsBuilder WithCost(decimal cost);
        TransactionItemsBuilder WithDocumentId(int documentId);
        TransactionItemsBuilder WithItemId(int itemId);
        TransactionItemsBuilder WithParticulars(string particulars);
        TransactionItemsBuilder WithPrice(decimal price);
        TransactionItemsBuilder WithQuantity(int quantity);
        TransactionItemsBuilder WithUnitName(string unitName);
    }
}