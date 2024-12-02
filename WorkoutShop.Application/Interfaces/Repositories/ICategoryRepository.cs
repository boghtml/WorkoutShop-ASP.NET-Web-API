using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutShop.Domain.Entities;

namespace WorkoutShop.Application.RepositorieInterfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        Task SaveChangesAsync();

        void DetachEntity(Category category);
    }
}
