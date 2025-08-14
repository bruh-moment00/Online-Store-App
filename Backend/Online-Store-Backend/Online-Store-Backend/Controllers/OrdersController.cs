using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Store_Backend.AuthHelpers;
using Online_Store_Backend.Database.Users.Models;
using Online_Store_Backend.Domain.Orders.Dto;
using Online_Store_Backend.Domain.Orders.Services.Interfaces;
using Online_Store_Backend.Enums;

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
            if (User == null && order == null) return NotFound();
            else if (!(HttpContext.User.IsInRole("employee") || AuthHelper.CheckSameUserId(HttpContext, order.UserID)))
            {
                return Forbid("Access denied");
            }
            else return Ok(order);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetOrders(long? userId = null ,int pageNumber = 1, int pageSize = 10)
        {
            if (userId == null && !HttpContext.User.IsInRole("employee"))
            {
                return Forbid("Access denied");
            }
            else if (userId.HasValue && !(HttpContext.User.IsInRole("employee") || AuthHelper.CheckSameUserId(HttpContext, (long)userId)))
            {
                return Forbid("Access denied");
            }
            var orders = await orderService.GetOrders(userId, pageNumber, pageSize);
            return Ok(orders);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<long>> InsertOrder()
        {
            var userId = HttpContext.User.IsInRole("user") ? HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id")?.Value : null;

            if (userId == null)
            {
                return BadRequest("User ID is required to create an order");
            }
            var orderId = await orderService.CreateOrder(Convert.ToInt64(userId));
            return orderId > 0 ? Ok(orderId) : BadRequest("Failed to insert order");
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateOrder([FromBody] OrderDto order)
        {
            if (!HttpContext.User.IsInRole("employee"))
            {
                if (order.Status != OrderStatus.Paid || !AuthHelper.CheckSameUserId(HttpContext, order.UserID))
                {
                    return Forbid("Нет доступа");
                }
            }
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

        [Authorize]
        [HttpGet("products")]
        public async Task<IActionResult> GetOrderedProducts(long orderId)
        {
            var order = await orderService.GetById(orderId);
            if (order == null)
            {
                return NotFound("Order not found");
            }
            else if (!(HttpContext.User.IsInRole("employee") || AuthHelper.CheckSameUserId(HttpContext, order.UserID)))
            {
                return Forbid("Access denied");
            }
            var orderedProducts = await orderedProductService.GetByOrderId(orderId);
            return Ok(orderedProducts);
        }

        [Authorize]
        [HttpPost("products")]
        public async Task<ActionResult<long>> AddProductToOrder([FromBody] OrderedProductDto orderedProduct)
        {
            var order = await orderService.GetById(orderedProduct.OrderID);
            if (orderedProduct == null || order == null)
            {
                return BadRequest("Ordered product is null or order not found");
            }
            else if (!(HttpContext.User.IsInRole("employee") || AuthHelper.CheckSameUserId(HttpContext, order.UserID)))
            {
                return Forbid("Access denied");
            }
            var result = await orderedProductService.InsertOrderedProduct(orderedProduct);
            return Ok(result);
        }

        [Authorize]
        [HttpDelete("products/{id}")]
        public async Task<IActionResult> DeleteOrderedProduct(long id)
        {
            var orderedProduct = await orderedProductService.GetById(id);
            if (orderedProduct == null)
            {
                return NotFound("Ordered product not found");
            }
            var order = await orderService.GetById(orderedProduct.OrderID);
            if (!(HttpContext.User.IsInRole("employee") || AuthHelper.CheckSameUserId(HttpContext, order.UserID)))
            {
                return Forbid("Access denied");
            }
            var result = await orderedProductService.DeleteOrderedProduct(id);
            return result ? Ok(result) : NotFound("Delete failed");
        }
    }
}
