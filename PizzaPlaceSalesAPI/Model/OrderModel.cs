using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaPlaceSalesAPI.Model
{
    public class OrderModel
    {
        [Key]
        public int order_id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string date { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string time { get; set; }
    }
}
