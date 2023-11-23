using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.ModelsBanco;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionsController : ControllerBase
    {
        private readonly BancoContext _context;

        public TransaccionsController(BancoContext context)
        {
            _context = context;
        }

        // GET: api/Transaccions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaccion>>> GetTransacciones()
        {
          if (_context.Transacciones == null)
          {
              return NotFound();
          }
            return await _context.Transacciones.ToListAsync();
        }

        // GET: api/Transaccions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaccion>> GetTransaccion(string id)
        {
          if (_context.Transacciones == null)
          {
              return NotFound();
          }
            var transaccion = await _context.Transacciones.FindAsync(id);

            if (transaccion == null)
            {
                return NotFound();
            }

            return transaccion;
        }

        // PUT: api/Transaccions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaccion(string id, Transaccion transaccion)
        {
            if (id != transaccion.id_movimientos)
            {
                return BadRequest();
            }

            _context.Entry(transaccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransaccionExists(id))
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

        // POST: api/Transaccions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transaccion>> PostTransaccion(Transaccion transaccion)
        {
          if (_context.Transacciones == null)
          {
              return Problem("Entity set 'BancoContext.Transacciones'  is null.");
          }
            _context.Transacciones.Add(transaccion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TransaccionExists(transaccion.id_movimientos))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTransaccion", new { id = transaccion.id_movimientos }, transaccion);
        }

        // DELETE: api/Transaccions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaccion(string id)
        {
            if (_context.Transacciones == null)
            {
                return NotFound();
            }
            var transaccion = await _context.Transacciones.FindAsync(id);
            if (transaccion == null)
            {
                return NotFound();
            }

            _context.Transacciones.Remove(transaccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransaccionExists(string id)
        {
            return (_context.Transacciones?.Any(e => e.id_movimientos == id)).GetValueOrDefault();
        }
    }
}
