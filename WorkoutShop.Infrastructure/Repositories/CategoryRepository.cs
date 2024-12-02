using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkoutShop.Application.RepositorieInterfaces;
using WorkoutShop.Domain.Entities;
using WorkoutShop.Infrastructure.Data;

namespace WorkoutShop.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void DetachEntity(Category category)
        {
            _context.Entry(category).State = EntityState.Detached;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                category.CreatedAt = DateTime.SpecifyKind(category.CreatedAt, DateTimeKind.Utc);
                if (category.UpdatedAt.HasValue)
                {
                    category.UpdatedAt = DateTime.SpecifyKind(category.UpdatedAt.Value, DateTimeKind.Utc);
                }
            }
            return category;
        }


        public async Task AddCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
