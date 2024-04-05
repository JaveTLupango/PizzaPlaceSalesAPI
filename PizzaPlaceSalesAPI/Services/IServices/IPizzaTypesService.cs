using Microsoft.EntityFrameworkCore;
using PizzaPlaceSalesAPI.Model;

namespace PizzaPlaceSalesAPI.Services.IServices
{
    public interface IPizzaTypesService
    {
        Task<bool> InsertBulkPizzaType(Stream file);
        DbSet<PizzaTypeModel> GetPizzaType();

    }
}
