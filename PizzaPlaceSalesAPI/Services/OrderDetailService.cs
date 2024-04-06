using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using PizzaPlaceSalesAPI.Model;
using PizzaPlaceSalesAPI.Model.DBContext;
using PizzaPlaceSalesAPI.Services.IServices;

namespace PizzaPlaceSalesAPI.Services
{
    public class OrderDetailService: IOrderDetailService
    {
        public readonly ICSVService _csvService;
        public readonly PizzaDBContext _dbContext;
        public OrderDetailService(ICSVService csvService, PizzaDBContext dBContext)
        {
            _csvService = csvService;
            _dbContext = dBContext;
        }

        private List<OrderDetailsModel> ConvertDataFromCSVToList(Stream file)
        {
            List<OrderDetailsModel> list = _csvService.ReadCSV<OrderDetailsModel>(file).ToList();
            return list;
        }

        public async Task<bool> InsertBulkOrderDetails(Stream file)
        {
            try
            {
                List<OrderDetailsModel> list = ConvertDataFromCSVToList(file);

                await _dbContext.BulkInsertAsync(list);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DbSet<OrderDetailsModel> GetOrderDetails()
        {
            return _dbContext.order_details;
        }
    }
}
