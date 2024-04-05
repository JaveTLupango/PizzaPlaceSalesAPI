using CsvHelper;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PizzaPlaceSalesAPI.Model;
using PizzaPlaceSalesAPI.Model.DBContext;
using PizzaPlaceSalesAPI.Services;
using PizzaPlaceSalesAPI.Services.IServices;
using System.Data;
using System.Globalization;
using System.Threading;

namespace PizzaPlaceSalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService; // Service Initialization of Pizza Service.

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }
        /// <summary>
        /// GET: api/Pizza
        /// </summary>
        /// <returns>return model Pizza model </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzasModel>>> GetPizzas()
        {
            return await _pizzaService.GetPizzas().ToListAsync();
        }

        /// <summary>
        /// GET: API/Pizzas/GetPizzasWithTypeDetails
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPizzasWithTypeDetails")]
        public async Task<List<PizzasTempModel>> GetPizzasWithTypeDetails()
        {
            string response = await _pizzaService.GetPizzasWithTypeDetails();
            List<PizzasTempModel> list = JsonConvert.DeserializeObject<List<PizzasTempModel>>(response);
            return list;
        }

        /// <summary>
        /// POST: api/pizzas/GetByID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetByID")]
        public async Task<ActionResult<IEnumerable<PizzasModel>>> GetByID(string id)
        {
            return await _pizzaService.GetPizzas().Where(s => s.pizza_id.ToLower() == id.ToLower()).ToListAsync();
        }

        /// <summary>
        /// POST: API/Pizzas/GetPizzasWithTypeDetails
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetByIdWithTypeDetails")]
        public async Task<List<PizzasTempModel>> GetByIdWithTypeDetails(string id)
        {
            string response = await _pizzaService.GetListOfPizzaByIdWithTypeDetails(id);
            List<PizzasTempModel> list = JsonConvert.DeserializeObject<List<PizzasTempModel>>(response);
            return list;
        }


        /// <summary>
        /// POST: api/Pizza/BulkInsert
        /// bulk insertion of pizza endpoint
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("BulkInsert")]
        public async Task<IActionResult> BulkInsertPizza([FromForm] IFormFileCollection file)
        {
            try
            {
                var ret = await _pizzaService.InsertBulkPizza(file[0].OpenReadStream());
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
