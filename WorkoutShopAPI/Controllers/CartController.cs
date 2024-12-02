using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WorkoutShop.Application.ServiceInterfaces;
using WorkoutShop.Domain.Entities;

namespace WorkoutShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly UserManager<User> _userManager;

        public CartController(IShoppingCartService shoppingCartService, UserManager<User> userManager)
        {
            _shoppingCartService = shoppingCartService;
            _userManager = userManager;
        }

        // 1. Отримання товарів у кошику для авторизованого користувача
        [HttpGet]
        public async Task<IActionResult> GetCartItems()
        {

            var userName = User?.Identity?.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return Unauthorized("User not found in token.");
            }

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return Unauthorized("User not found.");
            }

            var cart = await _shoppingCartService.GetCartByUserIdAsync(user.Id);
            if (cart == null || !cart.CartItems.Any())
            {
                return Ok("Your cart is empty.");
            }

            return Ok(cart.CartItems.Select(ci => new
            {
                ci.CartItemId,
                ci.ProductId,
                ci.Product.Name,
                ci.Product.Price,
                ci.Quantity,
                Total = ci.Quantity * ci.Product.Price
            }));
        }

        // 2. Додавання товару в кошик
        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] CartItemDto cartItemDto)
        {
            var userName = User?.Identity?.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return Unauthorized("User not found in token.");
            }

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return Unauthorized("User not found.");
            }

            await _shoppingCartService.AddToCartAsync(user.Id, cartItemDto.ProductId, cartItemDto.Quantity);
            return Ok("Product added to cart successfully.");
        }


        // 3. Оновлення кількості товару в кошику
        [HttpPut("{cartItemId}")]
        public async Task<IActionResult> UpdateCartItemQuantity(int cartItemId, [FromBody] CartItemUpdateDto updateDto)
        {
            var userName = User?.Identity?.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return Unauthorized("User not found in token.");
            }

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return Unauthorized("User not found.");
            }

            await _shoppingCartService.UpdateCartItemQuantityAsync(user.Id, cartItemId, updateDto.Quantity);
            return Ok("Cart item quantity updated successfully.");
        }

        // 4. Видалення товару з кошика
        [HttpDelete("{cartItemId}")]
        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
            var userName = User?.Identity?.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return Unauthorized("User not found in token.");
            }

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return Unauthorized("User not found.");
            }

            await _shoppingCartService.RemoveFromCartAsync(user.Id, cartItemId);
            return Ok("Product removed from cart successfully.");
        }
    }

    public class CartItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
    public class CartItemUpdateDto
    {
        public int Quantity { get; set; }
    }
}
