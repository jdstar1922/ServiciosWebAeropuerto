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
    public class VueloesController : ControllerBase
    {
        private readonly AeropuertoContext _context;

        public VueloesController(AeropuertoContext context)
        {
            _context = context;
        }

        // GET: api/Vueloes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vuelo>>> GetVuelos()
        {
          if (_context.Vuelos == null)
          {
              return NotFound();
          }
            return await _context.Vuelos.ToListAsync();
        }

        // GET: api/Vueloes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vuelo>> GetVuelo(string id)
        {
          if (_context.Vuelos == null)
          {
              return NotFound();
          }
            var vuelo = await _context.Vuelos.FindAsync(id);

            if (vuelo == null)
            {
                return NotFound();
            }

            return vuelo;
        }

        // PUT: api/Vueloes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVuelo(string id, Vuelo vuelo)
        {
            if (id != vuelo.cod_vuelo)
            {
                return BadRequest();
            }

            _context.Entry(vuelo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VueloExists(id))
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

        // POST: api/Vueloes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vuelo>> PostVuelo(Vuelo vuelo)
        {
          if (_context.Vuelos == null)
          {
              return Problem("Entity set 'AeropuertoContext.Vuelos'  is null.");
          }
            _context.Vuelos.Add(vuelo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VueloExists(vuelo.cod_vuelo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVuelo", new { id = vuelo.cod_vuelo }, vuelo);
        }

        // DELETE: api/Vueloes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVuelo(string id)
        {
            if (_context.Vuelos == null)
            {
                return NotFound();
            }
            var vuelo = await _context.Vuelos.FindAsync(id);
            if (vuelo == null)
            {
                return NotFound();
            }

            _context.Vuelos.Remove(vuelo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VueloExists(string id)
        {
            return (_context.Vuelos?.Any(e => e.cod_vuelo == id)).GetValueOrDefault();
        }
    }
}
