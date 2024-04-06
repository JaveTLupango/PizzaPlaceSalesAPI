using Microsoft.EntityFrameworkCore;
using PizzaPlaceSalesAPI.Model;

namespace PizzaPlaceSalesAPI.Services.IServices
{
    public interface IOrderServices
    {
        Task<bool> InsertBulkOrders(Stream file);
        DbSet<OrderModel> GetOrders();
        Task<string> GetOrderDetails(int id);
    }
}
