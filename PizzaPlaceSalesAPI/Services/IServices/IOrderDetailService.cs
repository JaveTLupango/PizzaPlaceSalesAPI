using Microsoft.EntityFrameworkCore;
using PizzaPlaceSalesAPI.Model;

namespace PizzaPlaceSalesAPI.Services.IServices
{
    public interface IOrderDetailService
    {
        Task<bool> InsertBulkOrderDetails(Stream file);
        DbSet<OrderDetailsModel> GetOrderDetails();
    }
}
