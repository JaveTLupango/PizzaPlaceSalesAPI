using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaPlaceSalesAPI.Model;
using PizzaPlaceSalesAPI.Services.IServices;

namespace PizzaPlaceSalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaTypesController : ControllerBase
    {
        public readonly IPizzaTypesService _pizzatypeService; // Service Initialization of Pizza Type Service.

        /// <summary>
        /// Constructor of PizzaTypeController
        /// </summary>
        /// <param name="pizzaTypesService"></param>
        public PizzaTypesController(IPizzaTypesService pizzaTypesService)
        {
            _pizzatypeService = pizzaTypesService;
        }

        /// <summary>
        /// API/GET : Get List of PizzaType
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaTypeModel>>> Get()
        {
            return await _pizzatypeService.GetPizzaType().ToListAsync();
        }

        /// <summary>
        /// API/PizzaTypes/BulkInsert : BULK Insert Pizza Type
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("BulkInsert")]
        public async Task<IActionResult> BulkInsertPizzaType([FromForm] IFormFileCollection file)
        {
            try
            {
                await _pizzatypeService.InsertBulkPizzaType(file[0].OpenReadStream());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API/PizzaTypes/GetByTypeID 
        /// Get Pizza Type by TypeID
        /// </summary>
        /// <param name="typeID"></param>
        /// <returns></returns>
        [HttpPost("GetByTypeID")]
        public async Task<ActionResult<IEnumerable<PizzaTypeModel>>> GetByTypeID(string typeID)
        {
            return await _pizzatypeService.GetPizzaType().Where(s => s.pizza_type_id.ToLower() == typeID.ToLower()).ToListAsync();
        }

        /// <summary>
        /// API/PizzaTypes/GetByTypeCategory
        /// Get PizzaType By Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost("GetByTypeCategory")]
        public async Task<ActionResult<IEnumerable<PizzaTypeModel>>> GetByTypeCategory(string category)
        {
            return await _pizzatypeService.GetPizzaType().Where(s => s.category.ToLower() == category.ToLower()).ToListAsync();
        }

    }
}
