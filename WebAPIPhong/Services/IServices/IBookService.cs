using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIPhong.Models;

namespace WebAPIPhong.Services.IServices
{
    public interface IBookService
    {
        Task<List<Book>> GetAll();
        Task<Book> GetById(int id);
        Task Create(Book inputBook);
        Task Update(int id, Book inputBook);
        Task Delete(int id);
    }
}