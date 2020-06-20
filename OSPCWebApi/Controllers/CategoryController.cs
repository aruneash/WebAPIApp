using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OSPCBusinessLayer;
using OSPCDataAccessLayer.Context;
using OSPCDataAccessLayer.Entities;

namespace OSPCWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // private readonly OnlineShoppingContext _context;
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _categoryService.GetViewCategories();
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoryService.getViewCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Category/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(Category category)
        {
            await _categoryService.UpdateCategory(category);
            return Ok(category);
        }

        // POST: api/Category
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
           await _categoryService.AddCategory(category);
           return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteCategory(int id)
        {
            var category = await _categoryService.DeleteCategory(id);
            return category;
        }

        private bool CategoryExists(int id)
        {
            return _categoryService.CategoryExists(id);
        }
    }
}
