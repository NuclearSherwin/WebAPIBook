using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using WebAPIPhong.DbContext;
using WebAPIPhong.Models;
using WebAPIPhong.Services.IServices;

namespace WebAPIPhong.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // https:localhost:5001/api/books/
    public class BooksController : ControllerBase
    {
        // private fields
        private readonly ApplicationDbContext _db;
        private readonly IBookService _bookService;


        // constructor
        public BooksController(ApplicationDbContext db,IBookService bookService)
        {
            _db = db;
            _bookService = bookService;
        }
        
        [HttpGet]
        // https:localhost:5001/api/books
        public async Task<List<Book>> GetAll()
        {
            return await _bookService.GetAll();
        }

        [HttpGet("{id:int}")]
        // https:localhost:5001/api/books/{id}
        public async Task<Book> GetById([FromRoute] int id)
        {
            return await _bookService.GetById(id);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Book bookInput)
        {
            await _bookService.Create(bookInput);
            return Ok(StatusCode(201));
        }

        [HttpPut("update/{id:int}")]
        // https:localhost:5001/api/books/update/{id}
        public async Task<IActionResult> Update([FromRoute] int id, Book bookInputNew)
        {

            await _bookService.Update(id, bookInputNew);
            return StatusCode(200);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _bookService.Delete(id);

            return StatusCode(200);
        }
    }
}