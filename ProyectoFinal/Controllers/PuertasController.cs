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
    public class PuertasController : ControllerBase
    {
        private readonly AeropuertoContext _context;

        public PuertasController(AeropuertoContext context)
        {
            _context = context;
        }

        // GET: api/Puertas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Puerta>>> GetPuertas()
        {
          if (_context.Puertas == null)
          {
              return NotFound();
          }
            return await _context.Puertas.ToListAsync();
        }

        // GET: api/Puertas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Puerta>> GetPuerta(string id)
        {
          if (_context.Puertas == null)
          {
              return NotFound();
          }
            var puerta = await _context.Puertas.FindAsync(id);

            if (puerta == null)
            {
                return NotFound();
            }

            return puerta;
        }

        // PUT: api/Puertas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPuerta(string id, Puerta puerta)
        {
            if (id != puerta.cod_puerta)
            {
                return BadRequest();
            }

            _context.Entry(puerta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuertaExists(id))
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

        // POST: api/Puertas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Puerta>> PostPuerta(Puerta puerta)
        {
          if (_context.Puertas == null)
          {
              return Problem("Entity set 'AeropuertoContext.Puertas'  is null.");
          }
            _context.Puertas.Add(puerta);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PuertaExists(puerta.cod_puerta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPuerta", new { id = puerta.cod_puerta }, puerta);
        }

        // DELETE: api/Puertas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePuerta(string id)
        {
            if (_context.Puertas == null)
            {
                return NotFound();
            }
            var puerta = await _context.Puertas.FindAsync(id);
            if (puerta == null)
            {
                return NotFound();
            }

            _context.Puertas.Remove(puerta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PuertaExists(string id)
        {
            return (_context.Puertas?.Any(e => e.cod_puerta == id)).GetValueOrDefault();
        }
    }
}
