using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIPhong.DbContext;
using WebAPIPhong.Models;
using WebAPIPhong.Services.IServices;

namespace WebAPIPhong.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _db;

        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await GetCategoryById(id);
        }

        public async Task Create(Category inputCategory)
        {
            await _db.Categories.AddAsync(inputCategory);
            await _db.SaveChangesAsync();
        }
        

        public async Task Update(int id,Category inputCategory)
        {
            var categoryDb = await GetCategoryById(id);
            
            // assign new value
            categoryDb.Name = inputCategory.Name;
            categoryDb.Description = inputCategory.Description;

            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var categoryDb = await GetCategoryById(id);
            _db.Categories.Remove(categoryDb);
            await _db.SaveChangesAsync();
        }

        private async Task<Category> GetCategoryById(int id)
        {
            return await _db.Categories.FindAsync(id);
        }
    }
}