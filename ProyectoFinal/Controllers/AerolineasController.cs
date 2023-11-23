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
    public class AerolineasController : ControllerBase
    {
        private readonly AeropuertoContext _context;

        public AerolineasController(AeropuertoContext context)
        {
            _context = context;
        }

        // GET: api/Aerolineas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aerolinea>>> GetAerolineas()
        {
          if (_context.Aerolineas == null)
          {
              return NotFound();
          }
            return await _context.Aerolineas.ToListAsync();
        }

        // GET: api/Aerolineas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aerolinea>> GetAerolinea(string id)
        {
          if (_context.Aerolineas == null)
          {
              return NotFound();
          }
            var aerolinea = await _context.Aerolineas.FindAsync(id);

            if (aerolinea == null)
            {
                return NotFound();
            }

            return aerolinea;
        }

        // PUT: api/Aerolineas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAerolinea(string id, Aerolinea aerolinea)
        {
            if (id != aerolinea.id_aerolinea)
            {
                return BadRequest();
            }

            _context.Entry(aerolinea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AerolineaExists(id))
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

        // POST: api/Aerolineas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aerolinea>> PostAerolinea(Aerolinea aerolinea)
        {
          if (_context.Aerolineas == null)
          {
              return Problem("Entity set 'AeropuertoContext.Aerolineas'  is null.");
          }
            _context.Aerolineas.Add(aerolinea);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AerolineaExists(aerolinea.id_aerolinea))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAerolinea", new { id = aerolinea.id_aerolinea }, aerolinea);
        }

        // DELETE: api/Aerolineas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAerolinea(string id)
        {
            if (_context.Aerolineas == null)
            {
                return NotFound();
            }
            var aerolinea = await _context.Aerolineas.FindAsync(id);
            if (aerolinea == null)
            {
                return NotFound();
            }

            _context.Aerolineas.Remove(aerolinea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AerolineaExists(string id)
        {
            return (_context.Aerolineas?.Any(e => e.id_aerolinea == id)).GetValueOrDefault();
        }
    }
}
