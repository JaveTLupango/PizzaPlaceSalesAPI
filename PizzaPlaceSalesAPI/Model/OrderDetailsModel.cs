using System.ComponentModel.DataAnnotations;

namespace PizzaPlaceSalesAPI.Model
{
    public class OrderDetailsModel
    {
        [Key]
        public int order_details_id { get; set; }
        [Required]
        public string order_id { get;}
        [Required]
        public string pizza_id { get; set; }
        [Required]
        public int quantity { get; set;}
    }

    public class OrderDetailsTempModel
    {
        public int order_details_id { get; set; }
        public string order_id { get; }
        public string pizza_id { get; set; }
        public int quantity { get; set; }

    }
}
