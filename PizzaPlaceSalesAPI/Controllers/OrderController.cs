using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaPlaceSalesAPI.Model;
using PizzaPlaceSalesAPI.Services.IServices;

namespace PizzaPlaceSalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public readonly IOrderServices _services;
        public OrderController(IOrderServices services)
        {
            this._services = services;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderModel>>> Get()
        {
            return await this._services.GetOrders().ToListAsync();
        }

        [HttpPost("BulkInsert")]
        public async Task<IActionResult> BulkInsertOrder([FromForm] IFormFileCollection file)
        {
            try
            {
                await _services.InsertBulkOrders(file[0].OpenReadStream());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
