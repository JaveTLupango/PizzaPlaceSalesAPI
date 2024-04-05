using Microsoft.EntityFrameworkCore;
using PizzaPlaceSalesAPI.Model;

namespace PizzaPlaceSalesAPI.Services.IServices
{
    public interface IPizzaService
    {
        DbSet<PizzasModel> GetPizzas();
        Task<bool> InsertBulkPizza(Stream file);
        Task<string> GetPizzasWithTypeDetails();
        Task<string> GetListOfPizzaByIdWithTypeDetails(string id);
    }
}
