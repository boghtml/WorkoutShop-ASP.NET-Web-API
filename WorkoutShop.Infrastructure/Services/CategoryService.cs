using WorkoutShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutShop.Application.ServiceInterfaces;
using WorkoutShop.Application.RepositorieInterfaces;

namespace WorkoutShop.Infrastructure.Service
{ 
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllCategoriesAsync();
        }

        public async Task CreateCategoryAsync(Category category)
        {
            category.CreatedAt = DateTime.UtcNow;
            await _categoryRepository.AddCategoryAsync(category);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetCategoryByIdAsync(id);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            var existingCategory = await _categoryRepository.GetCategoryByIdAsync(category.CategoryId);
            if (existingCategory == null)
            {
                throw new Exception("Категорію не знайдено.");
            }

            // Оновлюємо властивості
            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;
            existingCategory.UpdatedAt = DateTime.UtcNow;

            await _categoryRepository.SaveChangesAsync();
        }



        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category != null)
            {
                _categoryRepository.DeleteCategory(category);
                await _categoryRepository.SaveChangesAsync();
            }
        }
    }
}
