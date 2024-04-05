using System.ComponentModel.DataAnnotations;

namespace PizzaPlaceSalesAPI.Model
{
    public class PizzaTypeModel
    {
        [Key]
        public string pizza_type_id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string ingredients { get; set; }
    }
}
