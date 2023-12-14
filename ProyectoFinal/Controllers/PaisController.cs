using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Migrations;
using ProyectoFinal.Models;
using ProyectoFinal.Utils;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly AeropuertoContext _context;

        public PaisController(AeropuertoContext context)
        {
            _context = context;
        }

        // GET: api/Pais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pais>>> GetPaises()
        {
          if (_context.Paises == null)
          {
              return NotFound();
          }
            return await _context.Paises.ToListAsync();
        }

        // GET: api/Pais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pais>> GetPais(string id)
        {
          if (_context.Paises == null)
          {
              return NotFound();
          }
            var pais = await _context.Paises.FindAsync(id);

            if (pais == null)
            {
                return NotFound();
            }

            return pais;
        }

        // PUT: api/Pais/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPais(string id, Pais pais)
        {
            if (id != pais.id_pais)
            {
                return BadRequest();
            }

            _context.Entry(pais).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaisExists(id))
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

        // POST: api/Pais
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pais>> PostPais(Pais pais)
        {
          if (_context.Paises == null)
          {
              return Problem("Entity set 'AeropuertoContext.Paises'  is null.");
          }
            ConsecutivoHandler con = new();
            
            string nuevo_id = await con.GetId("1", _context);
            
            if (nuevo_id == "") {
                return Problem("La cantidad máxima de consecutivos se ha usado");
            } else
            {
                pais.id_pais = nuevo_id;
            }

            _context.Paises.Add(pais);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PaisExists(pais.id_pais))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPais", new { id = pais.id_pais }, pais);
        }

        // DELETE: api/Pais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePais(string id)
        {
            if (_context.Paises == null)
            {
                return NotFound();
            }
            var pais = await _context.Paises.FindAsync(id);
            if (pais == null)
            {
                return NotFound();
            }

            _context.Paises.Remove(pais);
            ConsecutivoHandler con = new();
            string liberar = await con.LiberarConsecutivo("1", _context);
            if(liberar == null)
            {
                return Problem("Rango inicial alcanzado");
            }
            await _context.SaveChangesAsync();
           

           
            return NoContent();
        }

        private bool PaisExists(string id)
        {
            return (_context.Paises?.Any(e => e.id_pais == id)).GetValueOrDefault();
        }
    }
}
