namespace dsa_marketing.Data
{
    public class TransactionsModel
    {
        public int TransactionId { get; set; }
        public string MunicipalityName { get; set; }
        public string BarangayName { get; set; }
        public string PunongBarangayName { get; set; }
        public string BarangayTreasurerName { get; set; }
        public List<string> UnitName { get; set; }
        public List<string> Particulars { get; set; }
        public List<int> Quantity { get; set; }
        public List<decimal> Cost { get; set; }
        public List<decimal> Amount { get; set; }
        public decimal Price { get; set; }
        public string ModeOfProcurement { get; set; }
        public DateTime OpenDate { get; set; }
        public string OfficeLocation { get; set; }
        public string OfficeOfThe { get; set; }
        public string AwardedToThe { get; set; }
        public string OpeningQuotationsOffice { get; set; }
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
