
using WebApi.Data;
using WebApi.Models;
using Pomelo.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly Context _appDbContext;
        public ProductsController(Context appDbContext)
        {
            _appDbContext = appDbContext;

        }
        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> AddProduct( string name, int price, int typeProduct) 
        {
            Product product = new Product(name, price, typeProduct);          
            _appDbContext.Product.Add(product);
            await _appDbContext.SaveChangesAsync();
            return Ok(product);

        }

        [HttpGet]
        [Route("obtenertodos")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _appDbContext.Product.ToListAsync();
            return Ok(products);
        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _appDbContext.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _appDbContext.Product.Remove(product);
            await _appDbContext.SaveChangesAsync();
            return Ok(product);
        }



    }
}
