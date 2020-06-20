using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await _productService.GetViewProducts();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _productService.getViewProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }



    }
}
