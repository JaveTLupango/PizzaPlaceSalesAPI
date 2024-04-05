using CsvHelper;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly ICSVService _csvService;
        private readonly PizzaDBContext _context;
        private readonly IPizzaService _pizzaService;

        public PizzaController(PizzaDBContext context, ICSVService cSVService, IPizzaService pizzaService)
        {
            _context = context;
            _csvService = cSVService;
            _pizzaService = pizzaService;
        }
        /// <summary>
        /// GET: api/Pizza's
        /// </summary>
        /// <returns>return model Pizza model </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzasModel>>> GetPizzas()
        {
            return await _context.pizzas.ToListAsync();
        }

        [HttpPost("read-pizza-csv")]
        public async Task<IActionResult> BulkInsertPizza([FromForm] IFormFileCollection file)
        {
            try
            {
                List<PizzaTempModel> pizzas = _csvService.ReadCSV<PizzaTempModel>(file[0].OpenReadStream()).ToList();
                var ret = await _pizzaService.InsertBulkPizza(pizzas);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
