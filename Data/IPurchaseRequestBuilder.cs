namespace dsa_marketing.Models
{
    public interface IPurchaseRequestBuilder
    {
        PurchaseRequestModel Build();
        PurchaseRequestBuilder WithApprovedForIssuanceName(string approvedForIssuanceName);
        PurchaseRequestBuilder WithDeliveryDate(DateTime deliveryDate);
        PurchaseRequestBuilder WithDeliveryLocation(string deliveryLocation);
        PurchaseRequestBuilder WithDeliveryTerms(string deliveryTerms);
        PurchaseRequestBuilder WithDocumentId(int documentId);
        PurchaseRequestBuilder WithPurpose(string purpose);
        PurchaseRequestBuilder WithRequestDate(DateTime requestDate);
        PurchaseRequestBuilder WithRequestedByName(string requestedByName);
        PurchaseRequestBuilder WithRequestId(int requestId);
        PurchaseRequestBuilder WithRequestNumber(string requestNumber);
        PurchaseRequestBuilder WithRequestorName(string requestorName);
        PurchaseRequestBuilder WithRequisition(string requisition);
    }
}