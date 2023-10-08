using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dsa_marketing.Models
{
    public class TransactionsModel
    {
        public int TransactionId { get; set; }
        public string MunicipalityName { get; set; }
        public string BarangayName { get; set; }
    }
}
