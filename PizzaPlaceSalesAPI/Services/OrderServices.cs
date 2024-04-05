using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using PizzaPlaceSalesAPI.Model;
using PizzaPlaceSalesAPI.Model.DBContext;
using PizzaPlaceSalesAPI.Services.IServices;

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
    }
}
