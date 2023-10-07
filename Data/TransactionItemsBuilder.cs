namespace dsa_marketing.Models
{
    public class TransactionItemsBuilder : ITransactionItemsBuilder
    {
        private TransactionItemsModel _item = new TransactionItemsModel();

        public TransactionItemsBuilder WithItemId(int itemId)
        {
            _item.ItemId = itemId;
            return this;
        }

        public TransactionItemsBuilder WithDocumentId(int documentId)
        {
            _item.DocumentId = documentId;
            return this;
        }

        public TransactionItemsBuilder WithUnitName(string unitName)
        {
            _item.UnitName = unitName;
            return this;
        }

        public TransactionItemsBuilder WithParticulars(string particulars)
        {
            _item.Particulars = particulars;
            return this;
        }

        public TransactionItemsBuilder WithQuantity(int quantity)
        {
            _item.Quantity = quantity;
            return this;
        }

        public TransactionItemsBuilder WithCost(decimal cost)
        {
            _item.Cost = cost;
            return this;
        }

        public TransactionItemsBuilder WithAmount(decimal amount)
        {
            _item.Amount = amount;
            return this;
        }

        public TransactionItemsBuilder WithPrice(decimal price)
        {
            _item.Price = price;
            return this;
        }

        public TransactionItemsModel Build()
        {
            return _item;
        }
    }
}
