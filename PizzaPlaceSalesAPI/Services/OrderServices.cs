using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PizzaPlaceSalesAPI.Model;
using PizzaPlaceSalesAPI.Model.DBContext;
using PizzaPlaceSalesAPI.Services.IServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PizzaPlaceSalesAPI.Services
{
    public class OrderServices: IOrderServices
    {
        public readonly ICSVService _csvService; // DbContext Initialization.
        public readonly PizzaDBContext _dbContext; // Service Initialization of CSVService.

        /// <summary>
        /// Contructor of OrderServices 
        /// </summary>
        /// <param name="cSVService"></param>
        /// <param name="dbContext"></param>
        public OrderServices(ICSVService cSVService, PizzaDBContext dbContext)
        {
            _csvService = cSVService;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Private method handler for CSV to List
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private List<OrderModel> ConvertDataFromCSVToList(Stream file)
        {
            List<OrderModel> list = _csvService.ReadCSV<OrderModel>(file).ToList();
            return list;
        }

        /// <summary>
        /// Bulk Insertion Method
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<bool> InsertBulkOrders(Stream file)
        {
            try
            {
                List<OrderModel> list = ConvertDataFromCSVToList(file);

                await _dbContext.BulkInsertAsync(list);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Return Dataset of Pizza Type
        /// </summary>
        /// <returns></returns>
        public DbSet<OrderModel> GetOrders()
        {
            return _dbContext.orders;
        }

        /// <summary>
        /// get order by order id
        /// return orders with details.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> GetOrderDetails(int id)
        {
            var queryPZ = _dbContext.pizzas.Join(
                    _dbContext.pizza_type,
                    p1 => p1.pizza_type_id,
                    p2 => p2.pizza_type_id,
                    (p1, p2) => new
                    {
                        pizza_id = p1.pizza_id,
                        pizza_type_id = p2.pizza_type_id,
                        size = p1.size,
                        price = p1.price,
                        pizza_type = p2
                    }
                ).ToList();

            var queryOrder = (from q1 in _dbContext.orders.AsEnumerable().Where(w => w.order_id == id).ToList()
                              select new
                              {
                                  order_id = q1.order_id,
                                  date = q1.date,
                                  time = q1.time,
                                  order_details = 
                                  _dbContext.order_details.AsEnumerable().Where(w => w.order_id == q1.order_id).ToList()
                                  .Join(
                                      queryPZ,
                                      q2 => q2.pizza_id,
                                      q3 => q3.pizza_id,
                                      (q2, q3) => new
                                      {
                                          quantity = q2.quantity,
                                          pizza = q3
                                      }
                                      )
                              });

            return JsonConvert.SerializeObject(queryOrder);
           
        }
    }
}
