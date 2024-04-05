using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaPlaceSalesAPI.Model
{
    public class PizzasModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string pizza_id { get; set; }
        [Required]
        public PizzaTypeModel pizza_type_id { get; set; }
        [Required]
        [Column(TypeName = "char(1)")]
        public string size { get; set; }
        [Required]
        public decimal price { get; set; }
    }
}
