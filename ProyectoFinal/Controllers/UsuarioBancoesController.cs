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
    public class UsuarioBancoesController : ControllerBase
    {
        private readonly BancoContext _context;

        public UsuarioBancoesController(BancoContext context)
        {
            _context = context;
        }

        // GET: api/UsuarioBancoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioBanco>>> GetUsuarios()
        {
          if (_context.Usuarios == null)
          {
              return NotFound();
          }
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/UsuarioBancoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioBanco>> GetUsuarioBanco(string id)
        {
          if (_context.Usuarios == null)
          {
              return NotFound();
          }
            var usuarioBanco = await _context.Usuarios.FindAsync(id);

            if (usuarioBanco == null)
            {
                return NotFound();
            }

            return usuarioBanco;
        }

        // PUT: api/UsuarioBancoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioBanco(string id, UsuarioBanco usuarioBanco)
        {
            if (id != usuarioBanco.Cedula_usuario)
            {
                return BadRequest();
            }

            _context.Entry(usuarioBanco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioBancoExists(id))
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

        // POST: api/UsuarioBancoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioBanco>> PostUsuarioBanco(UsuarioBanco usuarioBanco)
        {
          if (_context.Usuarios == null)
          {
              return Problem("Entity set 'BancoContext.Usuarios'  is null.");
          }
            _context.Usuarios.Add(usuarioBanco);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsuarioBancoExists(usuarioBanco.Cedula_usuario))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsuarioBanco", new { id = usuarioBanco.Cedula_usuario }, usuarioBanco);
        }

        // DELETE: api/UsuarioBancoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioBanco(string id)
        {
            if (_context.Usuarios == null)
            {
                return NotFound();
            }
            var usuarioBanco = await _context.Usuarios.FindAsync(id);
            if (usuarioBanco == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuarioBanco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioBancoExists(string id)
        {
            return (_context.Usuarios?.Any(e => e.Cedula_usuario == id)).GetValueOrDefault();
        }
    }
}
