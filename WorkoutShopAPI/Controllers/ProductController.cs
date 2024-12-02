using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using System.Threading.Tasks;
using WorkoutShop.Application.ServiceInterfaces;
using WorkoutShop.Domain.Entities;
using WorkoutShopAPI.ViewModels;

namespace WorkoutShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly UserManager<User> _userManager;

        public ProductsController(IProductService productService, UserManager<User> userManager)
        {
            _productService = productService;
            _userManager = userManager;
        }


        // Отримання списку всіх товарів
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        // Отримання товару за ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound("Product not found.");
            }

            return Ok(product);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto model)
        {
            var roles = User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
            Console.WriteLine("Roles:");
            foreach (var role in roles)
            {
                Console.WriteLine(role);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                StockQuantity = model.StockQuantity,
                CategoryId = model.CategoryId,
                CreatedAt = DateTime.UtcNow,
            };

            foreach (var imageUrl in model.ImageUrls)
            {
                product.ProductImages.Add(new ProductImage
                {
                    ImageUrl = imageUrl,
                    IsPrimary = false,
                    CreatedAt = DateTime.UtcNow
                });
            }

            await _productService.CreateProductAsync(product, null);

            return Ok("Product created successfully.");
        }

        // Оновлення продукту (тільки для адміністратора)
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingProduct = await _productService.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound("Product not found.");
            }

            existingProduct.Name = model.Name;
            existingProduct.Description = model.Description;
            existingProduct.Price = model.Price;
            existingProduct.StockQuantity = model.StockQuantity;
            existingProduct.CategoryId = model.CategoryId;
            existingProduct.UpdatedAt = DateTime.UtcNow;

            foreach (var imageUrl in model.ImageUrls)
            {
                existingProduct.ProductImages.Add(new ProductImage
                {
                    ImageUrl = imageUrl,
                    IsPrimary = false,
                    CreatedAt = DateTime.UtcNow
                });
            }

            await _productService.UpdateProductAsync(existingProduct, null, new int[] { });

            return Ok("Product updated successfully.");
        }

        // Видалення продукту (тільки для адміністратора)
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound("Product not found.");
            }

            await _productService.DeleteProductAsync(id);

            return Ok("Product deleted successfully.");
        }

    }
}
