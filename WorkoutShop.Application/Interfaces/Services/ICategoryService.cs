using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutShop.Domain.Entities;

namespace WorkoutShop.Application.ServiceInterfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        Task CreateCategoryAsync(Category category);
        Task<Category> GetCategoryByIdAsync(int id);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
    }
}
