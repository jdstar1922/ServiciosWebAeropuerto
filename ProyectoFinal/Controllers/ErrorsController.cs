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
    public class ErrorsController : ControllerBase
    {
        private readonly AeropuertoContext _context;

        public ErrorsController(AeropuertoContext context)
        {
            _context = context;
        }

        // GET: api/Errors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Error>>> GetErrores()
        {
          if (_context.Errores == null)
          {
              return NotFound();
          }
            return await _context.Errores.ToListAsync();
        }

        // GET: api/Errors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Error>> GetError(string id)
        {
          if (_context.Errores == null)
          {
              return NotFound();
          }
            var error = await _context.Errores.FindAsync(id);

            if (error == null)
            {
                return NotFound();
            }

            return error;
        }

        // PUT: api/Errors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutError(string id, Error error)
        {
            if (id != error.id_error)
            {
                return BadRequest();
            }

            _context.Entry(error).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ErrorExists(id))
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

        // POST: api/Errors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Error>> PostError(Error error)
        {
          if (_context.Errores == null)
          {
              return Problem("Entity set 'AeropuertoContext.Errores'  is null.");
          }
            _context.Errores.Add(error);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ErrorExists(error.id_error))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetError", new { id = error.id_error }, error);
        }

        // DELETE: api/Errors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteError(string id)
        {
            if (_context.Errores == null)
            {
                return NotFound();
            }
            var error = await _context.Errores.FindAsync(id);
            if (error == null)
            {
                return NotFound();
            }

            _context.Errores.Remove(error);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ErrorExists(string id)
        {
            return (_context.Errores?.Any(e => e.id_error == id)).GetValueOrDefault();
        }
    }
}
