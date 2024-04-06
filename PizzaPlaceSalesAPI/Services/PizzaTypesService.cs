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
        public readonly PizzaDBContext _dbContext; // DbContext Initialization.
        public readonly ICSVService _csvService; // Service Initialization of CSVService.

        /// <summary>
        /// Contructor of PizzaTypesService
        /// </summary>
        /// <param name="pizzaDBContext"></param>
        /// <param name="cSVService"></param>
        public PizzaTypesService(PizzaDBContext pizzaDBContext, ICSVService cSVService)
        {
            this._dbContext = pizzaDBContext;
            this._csvService = cSVService;
        }

        /// <summary>
        /// Private method handler for CSV to List
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private List<PizzaTypeModel> ConvertDataFromCSVToList(Stream file)
        {
            List<PizzaTypeModel> list = this._csvService.ReadCSV<PizzaTypeModel>(file).ToList();
            return list;
        }

        /// <summary>
        /// Bulk Insertion Method
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<bool> InsertBulkPizzaType(Stream file)
        {
            try
            {
                List<PizzaTypeModel> list = ConvertDataFromCSVToList(file);

                await this._dbContext.BulkInsertAsync(list);
                await this._dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// return Dataset of Pizza Type
        /// </summary>
        /// <returns></returns>
        public DbSet<PizzaTypeModel> GetPizzaType()
        {
            return this._dbContext.pizza_type;
        }
    }
}
