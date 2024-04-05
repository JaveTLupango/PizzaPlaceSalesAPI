
using Microsoft.EntityFrameworkCore;

namespace PizzaPlaceSalesAPI.Model.DBContext
{
    public class PizzaDBContext: DbContext
    {
        public PizzaDBContext(DbContextOptions<PizzaDBContext> options) : base(options)
        {

        }
        public DbSet<PizzaTypeModel> pizza_type { get; set; }
        public DbSet<PizzasModel> pizzas { get; set; }
        public DbSet<OrderModel> orders { get; set; }
        public DbSet<OrderDetailsModel> order_details { get; set; }
    }
}
