namespace dsa_marketing.Models
{
    public class PurchaseRequestBuilder : IPurchaseRequestBuilder
    {
        private PurchaseRequestModel _purchaseRequest = new PurchaseRequestModel();

        public PurchaseRequestBuilder WithRequestId(int requestId)
        {
            _purchaseRequest.RequestId = requestId;
            return this;
        }

        public PurchaseRequestBuilder WithDocumentId(int documentId)
        {
            _purchaseRequest.DocumentId = documentId;
            return this;
        }

        public PurchaseRequestBuilder WithRequestNumber(string requestNumber)
        {
            _purchaseRequest.RequestNumber = requestNumber;
            return this;
        }

        public PurchaseRequestBuilder WithRequestDate(DateTime requestDate)
        {
            _purchaseRequest.RequestDate = requestDate;
            return this;
        }

        public PurchaseRequestBuilder WithRequisition(string requisition)
        {
            _purchaseRequest.Requisition = requisition;
            return this;
        }

        public PurchaseRequestBuilder WithDeliveryLocation(string deliveryLocation)
        {
            _purchaseRequest.DeliveryLocation = deliveryLocation;
            return this;
        }

        public PurchaseRequestBuilder WithDeliveryTerms(string deliveryTerms)
        {
            _purchaseRequest.DeliveryTerms = deliveryTerms;
            return this;
        }

        public PurchaseRequestBuilder WithDeliveryDate(DateTime deliveryDate)
        {
            _purchaseRequest.DeliveryDate = deliveryDate;
            return this;
        }

        public PurchaseRequestBuilder WithPurpose(string purpose)
        {
            _purchaseRequest.Purpose = purpose;
            return this;
        }

        public PurchaseRequestBuilder WithRequestedByName(string requestedByName)
        {
            _purchaseRequest.RequestedByName = requestedByName;
            return this;
        }

        public PurchaseRequestBuilder WithApprovedForIssuanceName(string approvedForIssuanceName)
        {
            _purchaseRequest.ApprovedForIssuanceName = approvedForIssuanceName;
            return this;
        }

        public PurchaseRequestBuilder WithRequestorName(string requestorName)
        {
            _purchaseRequest.RequestorName = requestorName;
            return this;
        }

        public PurchaseRequestModel Build()
        {
            return _purchaseRequest;
        }
    }
}
