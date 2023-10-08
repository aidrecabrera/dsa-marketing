using System.ComponentModel.DataAnnotations;

namespace dsa_marketing.Models
{
    public class TransactionDocumentsModel
    {
        [Key]
        public int DocumentId { get; set; }
        public int TransactionId { get; set; }
        public string PunongBarangayName { get; set; }
        public string BarangayTreasurerName { get; set; }
    }
}
