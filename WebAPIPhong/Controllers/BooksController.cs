using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPIPhong.DbContext;
using WebAPIPhong.Models;

namespace WebAPIPhong.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // https:localhost:5001/api/books/
    public class BooksController : ControllerBase
    {
        // private fields
        private readonly ApplicationDbContext _db;
        
        
        // constructor
        public BooksController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        // https:localhost:5001/api/books
        public IList<Book> GetAll()
        {
            return _db.Books.ToList();
        }

        [HttpGet("{id:int}")]
        // https:localhost:5001/api/books/{id}
        public Book GetById([FromRoute] int id)
        {
            return _db.Books.Find(id);
        }

        [HttpPost]
        public IActionResult Create(Book bookInput)
        {
            _db.Books.Add(bookInput);
            _db.SaveChanges();
            return Ok(StatusCode(201));
        } 
        
        
    }
}