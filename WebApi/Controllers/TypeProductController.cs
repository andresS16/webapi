using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeProductController : ControllerBase
    {
        private readonly Context _appDbContext;
        public TypeProductController(Context appDbContext)
        {
            _appDbContext = appDbContext;

        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> AddTypeProduct(string description)
        {
            TypeProduct tp = new TypeProduct(description);
            _appDbContext.TypeProduct.Add(tp);
            await _appDbContext.SaveChangesAsync();
            return Ok(tp);
        }
        [HttpGet]
        [Route("obtenertodos")]
        public async Task<IActionResult> GetAll()
        {
            var tps = await _appDbContext.TypeProduct.ToListAsync();
            return Ok(tps);
        }
        [HttpDelete]
        [Route("eliminar/{id}")]
        public async Task<IActionResult> DeleteTypeProduct(int id)
        {
            var tpDel = await _appDbContext.TypeProduct.FindAsync(id);
            if (tpDel == null)
            {
                return NotFound();
            }

            _appDbContext.TypeProduct.Remove(tpDel);
            await _appDbContext.SaveChangesAsync();
            return Ok(tpDel);
        }


    }
}
