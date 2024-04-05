using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PizzaPlaceSalesAPI.Model;
using PizzaPlaceSalesAPI.Model.DBContext;
using PizzaPlaceSalesAPI.Services.IServices;

namespace PizzaPlaceSalesAPI.Services
{
    public class PizzaService: IPizzaService
    {
        private readonly PizzaDBContext _context;

        public PizzaService(PizzaDBContext pizzaDBContext)
        {
            _context = pizzaDBContext;
        }

        public async Task<bool> InsertBulkPizza(List<PizzaTempModel> list)
        {
            try
            {
               await _context.BulkInsertAsync(list);

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
