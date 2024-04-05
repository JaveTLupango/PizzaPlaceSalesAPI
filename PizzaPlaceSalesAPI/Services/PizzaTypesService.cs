using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaPlaceSalesAPI.Model;
using PizzaPlaceSalesAPI.Model.DBContext;
using PizzaPlaceSalesAPI.Services.IServices;

namespace PizzaPlaceSalesAPI.Services
{
    public class PizzaTypesService: IPizzaTypesService
    {
        public readonly PizzaDBContext _dbContext;
        public readonly ICSVService _csvService;
        public PizzaTypesService(PizzaDBContext pizzaDBContext, ICSVService cSVService)
        {
            _dbContext = pizzaDBContext;
            _csvService = cSVService;
        }

        private List<PizzaTypeModel> ConvertDataFromCSVToList(Stream file)
        {
            List<PizzaTypeModel> list = _csvService.ReadCSV<PizzaTypeModel>(file).ToList();
            return list;
        }

        public async Task<bool> InsertBulkPizzaType(Stream file)
        {
            try
            {
                List<PizzaTypeModel> list = ConvertDataFromCSVToList(file);

                await _dbContext.BulkInsertAsync(list);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DbSet<PizzaTypeModel> GetPizzaType()
        {
            return _dbContext.pizza_type;
        }
    }
}
