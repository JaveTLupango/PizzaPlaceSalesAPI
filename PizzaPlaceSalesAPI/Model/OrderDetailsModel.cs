using System.ComponentModel.DataAnnotations;

namespace PizzaPlaceSalesAPI.Model
{
    public class OrderDetailsModel
    {
        [Key]
        public int order_details_id { get; set; }
        [Required]
        public OrderModel order_id { get;}
        [Required]
        public PizzasModel pizza_id { get; set; }
        [Required]
        public int quantity { get; set;}
    }
}
