﻿namespace dsa_marketing.Models
{
    public class PurchaseOrderModel
    {
        public int OrderId { get; set; }
        public int? DocumentId { get; set; }
        public string ModeOfProcurement { get; set; }
    }
}
