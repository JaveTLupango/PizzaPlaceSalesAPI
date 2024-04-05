using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaPlaceSalesAPI.Model
{
    public class PizzasModel
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string pizza_id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string pizza_type_id { get; set; }
        [Required]
        [Column(TypeName = "char(5)")]
        public string size { get; set; }
        [Required]
        public decimal price { get; set; }
    }

    public class PizzasTempModel
    {
        public string pizza_id { get; set; }
        public string pizza_type_id { get; set; }
        public string size { get; set; }
        public decimal price { get; set; }        
        public PizzaTypeModel pizza_type { get; set;}
    }

}
