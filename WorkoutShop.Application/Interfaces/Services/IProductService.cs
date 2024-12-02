using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutShop.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace WorkoutShop.Application.ServiceInterfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetFilteredProductsAsync(string searchTerm, int? categoryId, decimal? minPrice, decimal? maxPrice, string sortOrder);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task CreateProductAsync(Product product, string imageUrl);
        Task UpdateProductAsync(Product product, string imageUrl, int[] imagesToDelete);
        Task DeleteProductAsync(int id);
        bool ProductExists(int id);
    }
}
