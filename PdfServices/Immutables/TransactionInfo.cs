namespace dsa_marketing.PdfServices.Immutables
{
    public struct TransactionInfo
    {
        public string? Barangay { get; set; }
        public string? Municipality { get; set; }
        public string? Province { get; set; }

        public string? Supplier { get; set; }
        public string? Address { get; set; }

        public string? Po { get; set; }
        public string? Tin { get; set; }

        public string[] Mode => new string[] { "Bidding", "Negotiated", "Over the Counter" };

        public string? DeliveryPlace { get; set; }
        public string? DeliveryDate { get; set; }

        public string? TermDelivery { get; set; }
        public string? TermPayment { get; set; }

        public decimal? TotalAmount { get; set; }
        public string? PunongBarangay { get; set; }
        public string? BarangayTreasurer { get; set; }
    }
}