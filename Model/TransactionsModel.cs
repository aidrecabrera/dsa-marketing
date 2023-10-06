using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dsa_marketing.Model
{
    public class TransactionsModel
    {
        public int TID { get; set; }
        public string CityOrMunicipality { get; set; }
        public string Barangay { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
