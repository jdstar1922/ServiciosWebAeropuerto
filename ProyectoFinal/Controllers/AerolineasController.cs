using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;
using ProyectoFinal.Utils;

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
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "404 Not Found";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
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
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "404 Not Found";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return NotFound();
          }
            var aerolinea = await _context.Aerolineas.FindAsync(id);

            if (aerolinea == null)
            {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "404 Not Found";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
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
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "400 bad request";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return BadRequest();
            }

            _context.Entry(aerolinea).State = EntityState.Modified;

            try
            {
                Bitacora bitacora = new();
                bitacora.cod_registro = Guid.NewGuid().ToString();
                bitacora.date_registro = DateTime.Now;
                bitacora.tipo_registro = "Modificar";
                bitacora.descripcion_registro = "Modificar aerolinea";
                bitacora.detalle_registro = aerolinea.ToString();
                _context.Bitacoras.Add(bitacora);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AerolineaExists(id))
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

        // POST: api/Aerolineas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aerolinea>> PostAerolinea(Aerolinea aerolinea)
        {
          if (_context.Aerolineas == null)
          {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "Entity is null";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return Problem("Entity set 'AeropuertoContext.Aerolineas'  is null.");
          }

            ConsecutivoHandler con = new();

            string nuevo_id = await con.GetId("2", _context);

            if (nuevo_id == "")
            {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "cantidad maxima utilizada";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return Problem("La cantidad máxima de consecutivos se ha usado");
            }
            else
            {
                aerolinea.id_aerolinea = nuevo_id;
            }
            _context.Aerolineas.Add(aerolinea);
            try
            {
                Bitacora bitacora = new();
                bitacora.cod_registro = Guid.NewGuid().ToString();
                bitacora.date_registro = DateTime.Now;
                bitacora.tipo_registro = "Agregar";
                bitacora.descripcion_registro = "Agregar aerolinea";
                bitacora.detalle_registro = aerolinea.ToString();
                _context.Bitacoras.Add(bitacora);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AerolineaExists(aerolinea.id_aerolinea))
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

            return CreatedAtAction("GetAerolinea", new { id = aerolinea.id_aerolinea }, aerolinea);
        }

        // DELETE: api/Aerolineas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAerolinea(string id)
        {
            if (_context.Aerolineas == null)
            {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "404 Not Found";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return NotFound();
            }
            var aerolinea = await _context.Aerolineas.FindAsync(id);
            if (aerolinea == null)
            {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "404 Not Found";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return NotFound();
            }

            _context.Aerolineas.Remove(aerolinea);
            ConsecutivoHandler con = new();
            string liberar = await con.LiberarConsecutivo("2", _context);
            if (liberar == null)
            {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "Rango inicial alcanzado";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return Problem("Rango inicial alcanzado");
            }
            Bitacora bitacora = new();
            bitacora.cod_registro = Guid.NewGuid().ToString();
            bitacora.date_registro = DateTime.Now;
            bitacora.tipo_registro = "Remover";
            bitacora.descripcion_registro = "Remover aerolinea";
            bitacora.detalle_registro = aerolinea.ToString();
            _context.Bitacoras.Add(bitacora);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AerolineaExists(string id)
        {
            return (_context.Aerolineas?.Any(e => e.id_aerolinea == id)).GetValueOrDefault();
        }
    }
}
