using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PizzaPlaceSalesAPI.Model;
using PizzaPlaceSalesAPI.Services.IServices;

namespace PizzaPlaceSalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public readonly IOrderServices _services; // Service initialization of order service.
        public OrderController(IOrderServices services)
        {
            this._services = services;
        }

        /// <summary>
        /// get : api/order
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderModel>>> Get()
        {
            return await this._services.GetOrders().ToListAsync();
        }

        /// <summary>
        /// post: api/order/bulkinsert
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("BulkInsert")]
        public async Task<IActionResult> BulkInsertOrder([FromForm] IFormFileCollection file)
        {
            try
            {
                await this._services.InsertBulkOrders(file[0].OpenReadStream());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// post: api/order/getorderwithorderdetails
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetOrderWithOrderDetails")]
        public async Task<List<OrderWithDetailsTempModel>> GetOrderWithOrderDetails(int id)
        {
           string response =  await this._services.GetOrderDetails(id);
           List< OrderWithDetailsTempModel > list = JsonConvert.DeserializeObject<List<OrderWithDetailsTempModel>>(response);
           return list;
        }
    }
}
