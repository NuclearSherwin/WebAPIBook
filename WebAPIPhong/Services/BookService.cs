using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIPhong.DbContext;
using WebAPIPhong.Models;
using WebAPIPhong.Services.IServices;

namespace WebAPIPhong.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _db;

        public BookService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Book>> GetAll()
        {
            return await _db.Books.ToListAsync();
        }

        public async Task<Book> GetById(int id)
        {
            return await GetBookById(id);
        }

        public async Task Create(Book inputBook)
        {
            await _db.Books.AddAsync(inputBook);
            await _db.SaveChangesAsync();
        }

        public Task Update(Book inputBook)
        {
            throw new System.NotImplementedException();
        }

        public async Task Update(int id,Book inputBook)
        {
            var bookDb = await GetBookById(id);
            
            // assign new value
            bookDb.Tittle = inputBook.Tittle;
            bookDb.Author = inputBook.Author;
            bookDb.Category = inputBook.Category;
            bookDb.PageNum = inputBook.PageNum;

            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var bookDb = await GetBookById(id);
            _db.Books.Remove(bookDb);
            await _db.SaveChangesAsync();
        }

        private async Task<Book> GetBookById(int id)
        {
            return await _db.Books.FindAsync(id);
        }
    }
}