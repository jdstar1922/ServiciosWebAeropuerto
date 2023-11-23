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
    public class MantenimientoesController : ControllerBase
    {
        private readonly AeropuertoContext _context;

        public MantenimientoesController(AeropuertoContext context)
        {
            _context = context;
        }

        // GET: api/Mantenimientoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mantenimiento>>> GetMantenimientos()
        {
          if (_context.Mantenimientos == null)
          {
              return NotFound();
          }
            return await _context.Mantenimientos.ToListAsync();
        }

        // GET: api/Mantenimientoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mantenimiento>> GetMantenimiento(string id)
        {
          if (_context.Mantenimientos == null)
          {
              return NotFound();
          }
            var mantenimiento = await _context.Mantenimientos.FindAsync(id);

            if (mantenimiento == null)
            {
                return NotFound();
            }

            return mantenimiento;
        }

        // PUT: api/Mantenimientoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMantenimiento(string id, Mantenimiento mantenimiento)
        {
            if (id != mantenimiento.Id)
            {
                return BadRequest();
            }

            _context.Entry(mantenimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MantenimientoExists(id))
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

        // POST: api/Mantenimientoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mantenimiento>> PostMantenimiento(Mantenimiento mantenimiento)
        {
          if (_context.Mantenimientos == null)
          {
              return Problem("Entity set 'AeropuertoContext.Mantenimientos'  is null.");
          }
            _context.Mantenimientos.Add(mantenimiento);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MantenimientoExists(mantenimiento.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMantenimiento", new { id = mantenimiento.Id }, mantenimiento);
        }

        // DELETE: api/Mantenimientoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMantenimiento(string id)
        {
            if (_context.Mantenimientos == null)
            {
                return NotFound();
            }
            var mantenimiento = await _context.Mantenimientos.FindAsync(id);
            if (mantenimiento == null)
            {
                return NotFound();
            }

            _context.Mantenimientos.Remove(mantenimiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MantenimientoExists(string id)
        {
            return (_context.Mantenimientos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
