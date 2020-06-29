using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OSPCBusinessLayer;
using OSPCDataAccessLayer.Entities;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OSPCWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // private readonly OnlineShoppingContext _context;
        private IProductService _productService;
        private readonly ILogger _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            _logger.LogInformation("Start : Getting product List");
            var data = await _productService.GetViewProducts();
            _logger.LogInformation("Completed : prodect List", data);
            return data;

        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            _logger.LogInformation("Start : Getting product details for {id}",id);
            var product = await _productService.getViewProduct(id);

            if (product == null)
            {
                return NotFound();
            }
            _logger.LogInformation("Completed : product details for {Id}", product);
            return product;
        }



    }
}
