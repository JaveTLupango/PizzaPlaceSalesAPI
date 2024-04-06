using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PizzaPlaceSalesAPI.Model;
using PizzaPlaceSalesAPI.Model.DBContext;
using PizzaPlaceSalesAPI.Services.IServices;

namespace PizzaPlaceSalesAPI.Services
{
    public class PizzaService: IPizzaService
    {
        public readonly PizzaDBContext _dbContext; // DbContext Initialization.
        public readonly ICSVService _csvService; // Service Initialization of CSVService.

        public PizzaService(PizzaDBContext pizzaDBContext, ICSVService csvService)
        {
            this._dbContext = pizzaDBContext;
            this._csvService = csvService;
        }

        /// <summary>
        /// Bulk insertion of Pizza
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<bool> InsertBulkPizza(Stream file)
        {
            try
            {
                var pizzas = _csvService.ReadCSV<PizzasModel>(file).ToList();
                await this._dbContext.BulkInsertAsync(pizzas);
                await this._dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Pizza DataSets
        /// </summary>
        /// <returns></returns>
        public DbSet<PizzasModel> GetPizzas() 
        {
            return this._dbContext.pizzas;
        }

        /// <summary>
        /// Get list Pizza with pizza type details
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetPizzasWithTypeDetails()
        {
            var ret = this._dbContext.pizzas.Join(
                    this._dbContext.pizza_type,
                    p1 => p1.pizza_type_id,
                    p2 => p2.pizza_type_id,
                    (p1, p2) => new
                    {
                        pizza_id = p1.pizza_id,
                        pizza_type_id = p2.pizza_type_id,
                        size = p1.size,
                        price = p1.price,
                        pizza_type = p2
                    }
                ).ToList();

           return JsonConvert.SerializeObject(ret);            
        }

        /// <summary>
        /// Get List Of Pizza By Id With Type Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> GetListOfPizzaByIdWithTypeDetails(string id)
        {
            var ret = this._dbContext.pizzas.Join(
                    this._dbContext.pizza_type,
                    p1 => p1.pizza_type_id,
                    p2 => p2.pizza_type_id,
                    (p1, p2) => new
                    {
                        pizza_id = p1.pizza_id,
                        pizza_type_id = p2.pizza_type_id,
                        size = p1.size,
                        price = p1.price,
                        pizza_type = p2
                    }
                )
                .Where( w => w.pizza_id.ToLower() == id.ToLower())
                .ToList();

            return JsonConvert.SerializeObject(ret);
        }

    }
}
