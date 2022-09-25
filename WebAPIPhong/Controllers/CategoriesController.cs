using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPIPhong.DbContext;
using WebAPIPhong.Dtos;
using WebAPIPhong.Models;
using WebAPIPhong.Services.IServices;

namespace WebAPIPhong.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryService : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;


        // constructor
        public CategoryService(ApplicationDbContext db,
            ICategoryService categoryService,
            IMapper mapper )
        {
            _db = db;
            _categoryService = categoryService;
            _mapper = mapper;
        }
        
        [HttpGet]
        // https:localhost:5001/api/categories
        public async Task<List<Category>> GetAll()
        {
            return await _categoryService.GetAll();
        }

        [HttpGet("{id:int}")]
        // https:localhost:5001/api/categories/{id}
        public async Task<Category> GetById([FromRoute] int id)
        {
            return await _categoryService.GetById(id);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(UpsertCategoryDtos categoryInput)
        {
            var category = _mapper.Map<Category>(categoryInput);
            await _categoryService.Create(category);
            return Ok(StatusCode(201));
        }

        [HttpPut("update/{id:int}")]
        // https:localhost:5001/api/categories/update/{id}
        public async Task<IActionResult> Update([FromRoute] int id, UpsertCategoryDtos categoryInputNew)
        {

            var category = _mapper.Map<Category>(categoryInputNew);
            await _categoryService.Update(id, category);
            return StatusCode(200);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _categoryService.Delete(id);
            return StatusCode(200);
        }
    }
}