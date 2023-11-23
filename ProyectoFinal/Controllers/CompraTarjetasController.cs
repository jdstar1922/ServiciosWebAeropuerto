using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraTarjetasController : ControllerBase
    {
        private readonly AeropuertoContext _context;

        public CompraTarjetasController(AeropuertoContext context)
        {
            _context = context;
        }

        // GET: api/CompraTarjetas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompraTarjeta>>> GetComprasTarjeta()
        {
          if (_context.ComprasTarjeta == null)
          {
              return NotFound();
          }
            return await _context.ComprasTarjeta.ToListAsync();
        }

        // GET: api/CompraTarjetas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompraTarjeta>> GetCompraTarjeta(string id)
        {
          if (_context.ComprasTarjeta == null)
          {
              return NotFound();
          }
            var compraTarjeta = await _context.ComprasTarjeta.FindAsync(id);

            if (compraTarjeta == null)
            {
                return NotFound();
            }

            return compraTarjeta;
        }

        // PUT: api/CompraTarjetas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompraTarjeta(string id, CompraTarjeta compraTarjeta)
        {
            if (id != compraTarjeta.num_tarjeta)
            {
                return BadRequest();
            }

            _context.Entry(compraTarjeta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraTarjetaExists(id))
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

        // POST: api/CompraTarjetas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompraTarjeta>> PostCompraTarjeta(CompraTarjeta compraTarjeta)
        {
          if (_context.ComprasTarjeta == null)
          {
              return Problem("Entity set 'AeropuertoContext.ComprasTarjeta'  is null.");
          }
            _context.ComprasTarjeta.Add(compraTarjeta);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompraTarjetaExists(compraTarjeta.num_tarjeta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCompraTarjeta", new { id = compraTarjeta.num_tarjeta }, compraTarjeta);
        }

        // DELETE: api/CompraTarjetas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompraTarjeta(string id)
        {
            if (_context.ComprasTarjeta == null)
            {
                return NotFound();
            }
            var compraTarjeta = await _context.ComprasTarjeta.FindAsync(id);
            if (compraTarjeta == null)
            {
                return NotFound();
            }

            _context.ComprasTarjeta.Remove(compraTarjeta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompraTarjetaExists(string id)
        {
            return (_context.ComprasTarjeta?.Any(e => e.num_tarjeta == id)).GetValueOrDefault();
        }
    }
}
