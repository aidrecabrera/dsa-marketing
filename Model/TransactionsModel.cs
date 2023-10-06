using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dsa_marketing.Model
{
    using System;

    public class TransactionDocument
    {
        public int document_id { get; set; }
        public string municipality_name { get; set; }
        public string barangay_name { get; set; }
        public string punong_barangay_name { get; set; }
        public string barangay_treasurer_name { get; set; }
        public string unit_name { get; set; }
        public string particulars { get; set; }
        public int quantity { get; set; }
        public decimal cost { get; set; }
        public decimal amount { get; set; }
    }

    public class PurchaseOrder
    {
        public int order_id { get; set; }
        public int document_id { get; set; }
        public string mode_of_procurement { get; set; }
    }

    public class AbstractQuotation
    {
        public int quotation_id { get; set; }
        public int document_id { get; set; }
        public DateTime open_date { get; set; }
        public string office_location { get; set; }
        public string office_of_the { get; set; }
        public string awarded_to_the { get; set; }
        public string office_of { get; set; }
        public string opening_quotations_office { get; set; }
        public string chairman_name { get; set; }
        public string member1_name { get; set; }
        public string member2_name { get; set; }
        public string member3_name { get; set; }
        public string member4_name { get; set; }
        public string member5_name { get; set; }
        public string member6_name { get; set; }
    }

    public class PurchaseRequest
    {
        public int request_id { get; set; }
        public int document_id { get; set; }
        public string request_number { get; set; }
        public DateTime request_date { get; set; }
        public string requisition { get; set; }
        public string delivery_location { get; set; }
        public string delivery_terms { get; set; }
        public DateTime delivery_date { get; set; }
        public string purpose { get; set; }
        public string requested_by_name { get; set; }
        public string approved_for_issuance_name { get; set; }
        public string requestor_name { get; set; }
    }

    public class Transaction
    {
        public int document_id { get; set; }
        public string municipality_name { get; set; }
        public string barangay_name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
    }

}
