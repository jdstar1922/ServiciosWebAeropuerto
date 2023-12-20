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
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "404 Not Found";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
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
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "404 Not Found";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return NotFound();
          }
            var consecutivo = await _context.Consecutivos.FindAsync(id);

            if (consecutivo == null)
            {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "404 Not Found";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
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
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "400 bad request";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return BadRequest();
            }

            _context.Entry(consecutivo).State = EntityState.Modified;

            try
            {
                Bitacora bitacora = new();
                bitacora.cod_registro = Guid.NewGuid().ToString();
                bitacora.date_registro = DateTime.Now;
                bitacora.tipo_registro = "Modificar";
                bitacora.descripcion_registro = "Modificar consecutivo";
                bitacora.detalle_registro = consecutivo.ToString();
                _context.Bitacoras.Add(bitacora);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsecutivoExists(id))
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

        // POST: api/Consecutivoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Consecutivo>> PostConsecutivo(Consecutivo consecutivo)
        {
          if (_context.Consecutivos == null)
          {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "consecutivos is null";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return Problem("Entity set 'AeropuertoContext.Consecutivos'  is null.");
          }
            _context.Consecutivos.Add(consecutivo);
            try
            {
                Bitacora bitacora = new();
                bitacora.cod_registro = Guid.NewGuid().ToString();
                bitacora.date_registro = DateTime.Now;
                bitacora.tipo_registro = "Agregar";
                bitacora.descripcion_registro = "Agregar consecutivo";
                bitacora.detalle_registro = consecutivo.ToString();
                _context.Bitacoras.Add(bitacora);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ConsecutivoExists(consecutivo.id_consecutivo))
                {
                    Error error = new();
                    error.id_error = Guid.NewGuid().ToString();
                    error.fecha_error = $"{DateTime.Now}";
                    error.mensaje_error = "409 conflict";
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

            return CreatedAtAction("GetConsecutivo", new { id = consecutivo.id_consecutivo }, consecutivo);
        }

        // DELETE: api/Consecutivoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsecutivo(string id)
        {
            if (_context.Consecutivos == null)
            {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "404 Not Found";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return NotFound();
            }
            var consecutivo = await _context.Consecutivos.FindAsync(id);
            if (consecutivo == null)
            {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "404 Not Found";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return NotFound();
            }

            _context.Consecutivos.Remove(consecutivo);
            Bitacora bitacora = new();
            bitacora.cod_registro = Guid.NewGuid().ToString();
            bitacora.date_registro = DateTime.Now;
            bitacora.tipo_registro = "Eliminar";
            bitacora.descripcion_registro = "Eliminar consecutivo";
            bitacora.detalle_registro = consecutivo.ToString();
            _context.Bitacoras.Add(bitacora);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsecutivoExists(string id)
        {
            return (_context.Consecutivos?.Any(e => e.id_consecutivo == id)).GetValueOrDefault();
        }
    }
}
