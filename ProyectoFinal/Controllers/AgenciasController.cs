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
    public class AgenciasController : ControllerBase
    {
        private readonly AeropuertoContext _context;

        public AgenciasController(AeropuertoContext context)
        {
            _context = context;
        }

        // GET: api/Agencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agencia>>> GetAgencias()
        {
          if (_context.Agencias == null)
          {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "404 Not Found";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return NotFound();
          }
            return await _context.Agencias.ToListAsync();
        }

        // GET: api/Agencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agencia>> GetAgencia(string id)
        {
          if (_context.Agencias == null)
          {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "404 Not Found";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return NotFound();
          }
            var agencia = await _context.Agencias.FindAsync(id);

            if (agencia == null)
            {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "404 Not Found";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return NotFound();
            }

            return agencia;
        }

        // PUT: api/Agencias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgencia(string id, Agencia agencia)
        {
            if (id != agencia.cod_agencia)
            {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "400 Bad Request";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return BadRequest();
            }

            _context.Entry(agencia).State = EntityState.Modified;

            try
            {
                Bitacora bitacora = new();
                bitacora.cod_registro = Guid.NewGuid().ToString();
                bitacora.date_registro = DateTime.Now;
                bitacora.tipo_registro = "Modificar";
                bitacora.descripcion_registro = "Modificar agencia";
                bitacora.detalle_registro = agencia.ToString();
                _context.Bitacoras.Add(bitacora);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgenciaExists(id))
                {
                    Error error = new();
                    error.id_error = Guid.NewGuid().ToString();
                    error.fecha_error = $"{DateTime.Now}";
                    error.mensaje_error = "404 Not Found";
                    _context.Errores.Add(error);
                    await _context.SaveChangesAsync();
                    return NotFound();
                }
                else
                {
                    Error error = new();
                    error.id_error = Guid.NewGuid().ToString();
                    error.fecha_error = $"{DateTime.Now}";
                    error.mensaje_error = "desconocido";
                    _context.Errores.Add(error);
                    await _context.SaveChangesAsync();
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Agencias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Agencia>> PostAgencia(Agencia agencia)
        {
          if (_context.Agencias == null)
          {
              return Problem("Entity set 'AeropuertoContext.Agencias'  is null.");
          }
            _context.Agencias.Add(agencia);
            try
            {
                Bitacora bitacora = new();
                bitacora.cod_registro = Guid.NewGuid().ToString();
                bitacora.date_registro = DateTime.Now;
                bitacora.tipo_registro = "Agregar";
                bitacora.descripcion_registro = "Agregar agencia";
                bitacora.detalle_registro = agencia.ToString();
                _context.Bitacoras.Add(bitacora);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AgenciaExists(agencia.cod_agencia))
                {
                    Error error = new();
                    error.id_error = Guid.NewGuid().ToString();
                    error.fecha_error = $"{DateTime.Now}";
                    error.mensaje_error = "409 Conflict";
                    _context.Errores.Add(error);
                    await _context.SaveChangesAsync();
                    return Conflict();
                }
                else
                {
                    Error error = new();
                    error.id_error = Guid.NewGuid().ToString();
                    error.fecha_error = $"{DateTime.Now}";
                    error.mensaje_error = "desconocido";
                    _context.Errores.Add(error);
                    await _context.SaveChangesAsync();
                    throw;
                }
            }

            return CreatedAtAction("GetAgencia", new { id = agencia.cod_agencia }, agencia);
        }

        // DELETE: api/Agencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgencia(string id)
        {
            if (_context.Agencias == null)
            {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "404 Not Found";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return NotFound();
            }
            var agencia = await _context.Agencias.FindAsync(id);
            if (agencia == null)
            {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "404 Not Found";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return NotFound();
            }

            _context.Agencias.Remove(agencia);
            Bitacora bitacora = new();
            bitacora.cod_registro = Guid.NewGuid().ToString();
            bitacora.date_registro = DateTime.Now;
            bitacora.tipo_registro = "Remover";
            bitacora.descripcion_registro = "Remover agencia";
            bitacora.detalle_registro = agencia.ToString();
            _context.Bitacoras.Add(bitacora);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgenciaExists(string id)
        {
            return (_context.Agencias?.Any(e => e.cod_agencia == id)).GetValueOrDefault();
        }
    }
}
