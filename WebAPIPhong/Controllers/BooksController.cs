using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using WebAPIPhong.DbContext;
using WebAPIPhong.Dtos;
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
        private readonly IMapper _mapper;


        // constructor
        public BooksController(ApplicationDbContext db,
            IBookService bookService,
            IMapper mapper )
        {
            _db = db;
            _bookService = bookService;
            _mapper = mapper;
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
        public async Task<IActionResult> Create(UpsertBookDtos bookInput)
        {
            var book = _mapper.Map<Book>(bookInput);
            await _bookService.Create(book);
            return Ok(StatusCode(201));
        }

        [HttpPut("update/{id:int}")]
        // https:localhost:5001/api/books/update/{id}
        public async Task<IActionResult> Update([FromRoute] int id, UpsertBookDtos bookInputNew)
        {

            var book = _mapper.Map<Book>(bookInputNew);
            await _bookService.Update(id, book);
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