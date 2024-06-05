using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;
using Microsoft.AspNetCore.Cors;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("PermitirOrigenEspecifico")]
    public class StockController : ControllerBase
    {
        private readonly Context _appDbContext;
        public StockController(Context appDbContext)
        {
            _appDbContext = appDbContext;

        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> AddStock(int amount, int idProduct)
        {
            //Console.WriteLine($"{idProduct}");
            //Console.ReadLine();
            var existStock = await _appDbContext.Stock
                                           .FirstOrDefaultAsync(s => s.IdProduct== idProduct);
            Stock newStock;
            if (existStock != null)
            {
                existStock.Amount += amount;
                _appDbContext.Stock.Update(existStock);
                newStock = existStock;
            }
            else {
                 newStock = new Stock(amount, idProduct);
                _appDbContext.Stock.Add(newStock);
            }        
            await _appDbContext.SaveChangesAsync();
            return Ok(newStock);
        }
        [HttpGet]
        [Route("obtenertodos")]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _appDbContext.Stock.ToListAsync();
            return Ok(stocks);
        }
        [HttpDelete]
        [Route("eliminar/{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            var stockDel = await _appDbContext.Stock.FindAsync(id);
            if (stockDel == null)
            {
                return NotFound();
            }

            _appDbContext.Stock.Remove(stockDel);
            await _appDbContext.SaveChangesAsync();
            return Ok(stockDel);
        }
    }
}
