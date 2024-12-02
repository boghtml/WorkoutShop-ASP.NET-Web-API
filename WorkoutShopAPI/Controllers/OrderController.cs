using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutShop.Application.ServiceInterfaces;
using WorkoutShop.Domain.Entities;

namespace WorkoutShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<User> _userManager;

        public OrdersController(IOrderService orderService, UserManager<User> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        // Створення нового замовлення (POST /api/orders)
        [HttpPost]
        public async Task<IActionResult> CreateOrder()
        {

            var userName = User?.Identity?.Name;
            if (string.IsNullOrEmpty(userName))
            {
                return Unauthorized("User not found.");
            }

            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return Unauthorized("User not found.");
            }

            await _orderService.CreateOrderAsync(user.Id);

            return Ok("Order created successfully.");
        }

        // Отримання списку замовлень для користувача (GET /api/orders)
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var userName = User?.Identity?.Name;
            if (string.IsNullOrEmpty(userName))
            {
                return Unauthorized("User not found.");
            }

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return Unauthorized("User not found.");
            }

            var orders = await _orderService.GetOrdersByUserIdAsync(user.Id);
            return Ok(orders);
        }

        // Отримання деталей конкретного замовлення (GET /api/orders/{orderId})
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderDetails(int orderId)
        {
            var userName = User?.Identity?.Name;
            if (string.IsNullOrEmpty(userName))
            {
                return Unauthorized("User not found.");
            }

            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return Unauthorized("User not found.");
            }

            var order = await _orderService.GetOrderByIdAsync(orderId, user.Id);
            if (order == null)
            {
                return NotFound("Order not found.");
            }

            return Ok(order);
        }
    }
}
