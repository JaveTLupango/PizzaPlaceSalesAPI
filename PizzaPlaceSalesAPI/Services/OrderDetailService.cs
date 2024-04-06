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
            this._csvService = csvService;
            this._dbContext = dBContext;
        }

        private List<OrderDetailsModel> ConvertDataFromCSVToList(Stream file)
        {
            List<OrderDetailsModel> list = this._csvService.ReadCSV<OrderDetailsModel>(file).ToList();
            return list;
        }

        public async Task<bool> InsertBulkOrderDetails(Stream file)
        {
            try
            {
                List<OrderDetailsModel> list = ConvertDataFromCSVToList(file);

                await this._dbContext.BulkInsertAsync(list);
                await this._dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DbSet<OrderDetailsModel> GetOrderDetails()
        {
            return this._dbContext.order_details;
        }
    }
}
