using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIPhong.Models;

namespace WebAPIPhong.Services.IServices
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task<Category> GetById(int id);
        Task Create(Category inputCategory);
        Task Update(int id, Category inputCategory);
        Task Delete(int id);
    }
}