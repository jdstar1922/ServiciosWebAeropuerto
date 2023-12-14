using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;
using ProyectoFinal.Utils;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraEasyPaysController : ControllerBase
    {
        private readonly AeropuertoContext _context;

        public CompraEasyPaysController(AeropuertoContext context)
        {
            _context = context;
        }

        // GET: api/CompraEasyPays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompraEasyPay>>> GetComprasEasyPay()
        {
          if (_context.ComprasEasyPay == null)
          {
              return NotFound();
          }
            return await _context.ComprasEasyPay.ToListAsync();
        }

        // GET: api/CompraEasyPays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompraEasyPay>> GetCompraEasyPay(string id)
        {
          if (_context.ComprasEasyPay == null)
          {
              return NotFound();
          }
            var compraEasyPay = await _context.ComprasEasyPay.FindAsync(id);

            if (compraEasyPay == null)
            {
                return NotFound();
            }

            return compraEasyPay;
        }

        // PUT: api/CompraEasyPays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompraEasyPay(string id, CompraEasyPay compraEasyPay)
        {
            if (id != compraEasyPay.num_cuenta)
            {
                return BadRequest();
            }

            _context.Entry(compraEasyPay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraEasyPayExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CompraEasyPays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompraEasyPay>> PostCompraEasyPay(CompraEasyPay compraEasyPay)
        {
          if (_context.ComprasEasyPay == null)
          {
              return Problem("Entity set 'AeropuertoContext.ComprasEasyPay'  is null.");
          }

            ConsecutivoHandler con = new();

            string nuevo_id = await con.GetId("4", _context);

            if (nuevo_id == "")
            {
                return Problem("La cantidad máxima de consecutivos se ha usado");
            }
            else
            {
                compraEasyPay.num_cuenta = nuevo_id;
            }
            _context.ComprasEasyPay.Add(compraEasyPay);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompraEasyPayExists(compraEasyPay.num_cuenta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCompraEasyPay", new { id = compraEasyPay.num_cuenta }, compraEasyPay);
        }

        // DELETE: api/CompraEasyPays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompraEasyPay(string id)
        {
            if (_context.ComprasEasyPay == null)
            {
                return NotFound();
            }
            var compraEasyPay = await _context.ComprasEasyPay.FindAsync(id);
            if (compraEasyPay == null)
            {
                return NotFound();
            }

            _context.ComprasEasyPay.Remove(compraEasyPay);
            ConsecutivoHandler con = new();
            string liberar = await con.LiberarConsecutivo("4", _context);
            if (liberar == null)
            {
                return Problem("Rango inicial alcanzado");
            }
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompraEasyPayExists(string id)
        {
            return (_context.ComprasEasyPay?.Any(e => e.num_cuenta == id)).GetValueOrDefault();
        }
    }
}
