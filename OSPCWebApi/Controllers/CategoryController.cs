using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            _logger.LogInformation("Start : Getting category List");
            var data = await _categoryService.GetViewCategories();
            _logger.LogInformation("Completed : category List", data);
            return data;
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            _logger.LogInformation("Start : Getting category details for {id}", id);
            var category = await _categoryService.getViewCategory(id);

            if (category == null)
            {
                return NotFound();
            }
            _logger.LogInformation("Completed : category details for {Id}", category);
            return category;
        }
    }
}
