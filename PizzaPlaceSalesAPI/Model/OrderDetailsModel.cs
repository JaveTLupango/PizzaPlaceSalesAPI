using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaPlaceSalesAPI.Model
{
    public class OrderDetailsModel
    {
        [Key]
        public int order_details_id { get; set; }
        [Required]
        public int order_id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string pizza_id { get; set; }
        [Required]
        public int quantity { get; set;}
    }

    public class OrderDetails
    {
        public PizzasTempModel pizza { get; set; }
        public int quantity { get; set; }
    }
}
