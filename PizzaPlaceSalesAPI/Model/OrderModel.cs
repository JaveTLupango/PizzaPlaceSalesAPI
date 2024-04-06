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

    public class OrderWithDetailsTempModel
    {
        public int order_id { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public List<OrderDetails> order_details {  get; set; }

    }
}
