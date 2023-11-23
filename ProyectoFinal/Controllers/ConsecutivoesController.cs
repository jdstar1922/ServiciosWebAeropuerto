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
    public class ConsecutivoesController : ControllerBase
    {
        private readonly AeropuertoContext _context;

        public ConsecutivoesController(AeropuertoContext context)
        {
            _context = context;
        }

        // GET: api/Consecutivoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consecutivo>>> GetConsecutivos()
        {
          if (_context.Consecutivos == null)
          {
              return NotFound();
          }
            return await _context.Consecutivos.ToListAsync();
        }

        // GET: api/Consecutivoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Consecutivo>> GetConsecutivo(string id)
        {
          if (_context.Consecutivos == null)
          {
              return NotFound();
          }
            var consecutivo = await _context.Consecutivos.FindAsync(id);

            if (consecutivo == null)
            {
                return NotFound();
            }

            return consecutivo;
        }

        // PUT: api/Consecutivoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsecutivo(string id, Consecutivo consecutivo)
        {
            if (id != consecutivo.id_consecutivo)
            {
                return BadRequest();
            }

            _context.Entry(consecutivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsecutivoExists(id))
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

        // POST: api/Consecutivoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Consecutivo>> PostConsecutivo(Consecutivo consecutivo)
        {
          if (_context.Consecutivos == null)
          {
              return Problem("Entity set 'AeropuertoContext.Consecutivos'  is null.");
          }
            _context.Consecutivos.Add(consecutivo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ConsecutivoExists(consecutivo.id_consecutivo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetConsecutivo", new { id = consecutivo.id_consecutivo }, consecutivo);
        }

        // DELETE: api/Consecutivoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsecutivo(string id)
        {
            if (_context.Consecutivos == null)
            {
                return NotFound();
            }
            var consecutivo = await _context.Consecutivos.FindAsync(id);
            if (consecutivo == null)
            {
                return NotFound();
            }

            _context.Consecutivos.Remove(consecutivo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsecutivoExists(string id)
        {
            return (_context.Consecutivos?.Any(e => e.id_consecutivo == id)).GetValueOrDefault();
        }
    }
}
