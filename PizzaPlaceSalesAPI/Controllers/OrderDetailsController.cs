using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaPlaceSalesAPI.Model;
using PizzaPlaceSalesAPI.Services.IServices;

namespace PizzaPlaceSalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        public readonly IOrderDetailService _service;  // Service initialization of order details service.

        /// <summary>
        /// Constructor of OrderDetails Controller
        /// </summary>
        /// <param name="service"></param>
        public OrderDetailsController(IOrderDetailService service)
        {
            _service = service;
        }

        /// <summary>
        /// GET: api/orderdatails
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetailsModel>>> Get()
        {
            return await this._service.GetOrderDetails().ToListAsync();
        }

        /// <summary>
        /// post: api/orderdetails/bulkinsert
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("BulkInsert")]
        public async Task<IActionResult> BulkInsertOrderDetails([FromForm] IFormFileCollection file)
        {
            try
            {
                await _service.InsertBulkOrderDetails(file[0].OpenReadStream());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
