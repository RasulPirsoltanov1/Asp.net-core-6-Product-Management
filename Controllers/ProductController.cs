using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductProjectAPI.Core;
using ProductProjectAPI.Data;

namespace ProductProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        private static List<ProductEntity> _products { get; set; } = new List<ProductEntity>()
        {
              new ProductEntity()
                {
                    Id = 1,
                    Name = "adw",
                    Price = 124,
                },
                    new ProductEntity()
                {
                    Id = 2,
                    Name = "Rexona",
                    Price = 123,
                },
                      new ProductEntity()
                {
                    Id = 3,
                    Name = "Rexona",
                    Price = 123,
                },
                        new ProductEntity()
                {
                    Id = 4,
                    Name = "Rexona",
                    Price = 123,
                },
                          new ProductEntity()
                {
                    Id = 5,
                    Name = "Rexona",
                    Price = 123,
                },
        };
        [HttpGet("getProducts")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Products.ToListAsync());
        }
        [HttpGet("getProducts/{id}")]
        public async Task<ActionResult<ProductEntity>> GetById(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return BadRequest("Product Not Found!");
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductEntity productEntity)
        {
            try
            {
                _products.Add(productEntity);
                return Ok(_products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductEntity productEntity)
        {
            try
            {
                ProductEntity product = _products.FirstOrDefault(p => p.Id == id && p.Id == productEntity.Id);
                product.Name = productEntity.Name;
                product.Price = productEntity.Price;
                return Ok(_products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int[] id)
        {

            try
            {
                foreach (var i in id)
                {
                    var product = _products.Find(x => x.Id == i);
                    _products.Remove(product);
                }

                return Ok(_products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
