using PizzaPlaceSalesAPI.Model;

namespace PizzaPlaceSalesAPI.Services.IServices
{
    public interface IPizzaService
    {
        Task<bool> InsertBulkPizza(List<PizzaTempModel> list);
    }
}
