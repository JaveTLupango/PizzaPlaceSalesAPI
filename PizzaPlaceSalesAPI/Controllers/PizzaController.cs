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
        private readonly IPizzaService _service; // Service Initialization of Pizza Service.

        /// <summary>
        /// Constructor of PizzaController
        /// </summary>
        /// <param name="pizzaService"></param>
        public PizzaController(IPizzaService pizzaService)
        {
            this._service = pizzaService;
        }
        /// <summary>
        /// GET: api/Pizza
        /// </summary>
        /// <returns>return model Pizza model </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzasModel>>> GetPizzas()
        {
            return await this._service.GetPizzas().ToListAsync();
        }

        /// <summary>
        /// GET: API/Pizzas/GetPizzasWithTypeDetails
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPizzasWithTypeDetails")]
        public async Task<List<PizzasTempModel>> GetPizzasWithTypeDetails()
        {
            string response = await this._service.GetPizzasWithTypeDetails();
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
            return await this._service.GetPizzas().Where(s => s.pizza_id.ToLower() == id.ToLower()).ToListAsync();
        }

        /// <summary>
        /// POST: API/Pizzas/GetPizzasWithTypeDetails
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetByIdWithTypeDetails")]
        public async Task<List<PizzasTempModel>> GetByIdWithTypeDetails(string id)
        {
            string response = await this._service.GetListOfPizzaByIdWithTypeDetails(id);
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
                var ret = await this._service.InsertBulkPizza(file[0].OpenReadStream());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
