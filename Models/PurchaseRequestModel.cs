﻿namespace dsa_marketing.Models
{
    public class PurchaseRequestModel
    {
        public int RequestId { get; set; }
        public int DocumentId { get; set; }
        public string RequestNumber { get; set; }
        public DateTime RequestDate { get; set; }
        public string Requisition { get; set; }
        public string DeliveryLocation { get; set; }
        public string DeliveryTerms { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Purpose { get; set; }
        public string RequestedByName { get; set; }
        public string ApprovedForIssuanceName { get; set; }
        public string RequestorName { get; set; }
    }
}
