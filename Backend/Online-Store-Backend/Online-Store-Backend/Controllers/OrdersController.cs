using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Store_Backend.AuthHelpers;
using Online_Store_Backend.Domain.Orders.Dto;
using Online_Store_Backend.Domain.Orders.Services.Interfaces;
using System.Threading.Tasks;

namespace Online_Store_Backend.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IOrderedProductService orderedProductService;
        public OrdersController(IOrderService orderService, IOrderedProductService orderedProductService)
        {
            this.orderService = orderService;
            this.orderedProductService = orderedProductService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(long id)
        {
            var order = await orderService.GetById(id);
            if (User == null) return NotFound();
            else if (!(HttpContext.User.IsInRole("employee") || AuthHelper.CheckSameUserId(HttpContext, order.UserID)))
            {
                return Forbid("Access denied");
            }
            else return Ok(order);
        }

        [Authorize(Roles = "employee")]
        [HttpGet]
        public async Task<IActionResult> GetOrders(int page = 1, int size = 10)
        {
            var orders = await orderService.GetAll(page, size);
            return Ok(orders);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<long>> InsertOrder([FromBody] OrderDto order)
        {
            if (order == null)
            {
                return BadRequest("Order cannot be null");
            }
            else if (order.Status != Enums.OrderStatus.Pending)
            {
                return Forbid("You can only create orders with status Pending");
            }

            var orderId = await orderService.InsertOrder(order);
            return orderId > 0 ? Ok(orderId) : BadRequest("Failed to insert product");
        }

        [Authorize(Roles = "employee")]
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateOrder([FromBody] OrderDto order)
        {
            if (order == null)
            {
                return BadRequest("Order data is invalid");
            }
            var result = await orderService.UpdateOrder(order);
            return result ? Ok(result) : NotFound("Order not found or update failed");
        }

        [Authorize(Roles = "employee")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(long id)
        {
            var result = await orderService.DeleteOrder(id);
            return result ? Ok(result) : NotFound("Order not found or delete failed");
        }
    }
}
