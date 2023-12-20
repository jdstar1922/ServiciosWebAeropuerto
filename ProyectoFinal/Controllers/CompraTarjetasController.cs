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
    public class CompraTarjetasController : ControllerBase
    {
        private readonly AeropuertoContext _context;

        public CompraTarjetasController(AeropuertoContext context)
        {
            _context = context;
        }

        // GET: api/CompraTarjetas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompraTarjeta>>> GetComprasTarjeta()
        {
          if (_context.ComprasTarjeta == null)
          {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "404 Not Found";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return NotFound();
          }
            return await _context.ComprasTarjeta.ToListAsync();
        }

        // GET: api/CompraTarjetas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompraTarjeta>> GetCompraTarjeta(string id)
        {
          if (_context.ComprasTarjeta == null)
          {
              return NotFound();
          }
            var compraTarjeta = await _context.ComprasTarjeta.FindAsync(id);

            if (compraTarjeta == null)
            {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "404 Not Found";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return NotFound();
            }

            return compraTarjeta;
        }

        // PUT: api/CompraTarjetas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompraTarjeta(string id, CompraTarjeta compraTarjeta)
        {
            if (id != compraTarjeta.num_tarjeta)
            {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "400 bad Request";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return BadRequest();
            }

            ConsecutivoHandler con = new();

            string nuevo_id = await con.GetId("5", _context);

            if (nuevo_id == "")
            {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "cantidad maxima";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return Problem("La cantidad máxima de consecutivos se ha usado");
            }
            else
            {
                compraTarjeta.num_tarjeta = nuevo_id;
            }
            _context.Entry(compraTarjeta).State = EntityState.Modified;

            try
            {
                Bitacora bitacora = new();
                bitacora.cod_registro = Guid.NewGuid().ToString();
                bitacora.date_registro = DateTime.Now;
                bitacora.tipo_registro = "Modificar";
                bitacora.descripcion_registro = "Modificar compra";
                bitacora.detalle_registro = compraTarjeta.ToString();
                _context.Bitacoras.Add(bitacora);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraTarjetaExists(id))
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

        // POST: api/CompraTarjetas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompraTarjeta>> PostCompraTarjeta(CompraTarjeta compraTarjeta)
        {
          if (_context.ComprasTarjeta == null)
          {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "compras tarjeta null";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return Problem("Entity set 'AeropuertoContext.ComprasTarjeta'  is null.");
          }
            _context.ComprasTarjeta.Add(compraTarjeta);
            try
            {
                Bitacora bitacora = new();
                bitacora.cod_registro = Guid.NewGuid().ToString();
                bitacora.date_registro = DateTime.Now;
                bitacora.tipo_registro = "Agregar";
                bitacora.descripcion_registro = "Agregar compra";
                bitacora.detalle_registro = compraTarjeta.ToString();
                _context.Bitacoras.Add(bitacora);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompraTarjetaExists(compraTarjeta.num_tarjeta))
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

            return CreatedAtAction("GetCompraTarjeta", new { id = compraTarjeta.num_tarjeta }, compraTarjeta);
        }

        // DELETE: api/CompraTarjetas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompraTarjeta(string id)
        {
            if (_context.ComprasTarjeta == null)
            {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "404 Not Found";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return NotFound();
            }
            var compraTarjeta = await _context.ComprasTarjeta.FindAsync(id);
            if (compraTarjeta == null)
            {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "404 Not Found";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return NotFound();
            }

            _context.ComprasTarjeta.Remove(compraTarjeta);
            ConsecutivoHandler con = new();
            string liberar = await con.LiberarConsecutivo("5", _context);
            if (liberar == null)
            {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "rango inicial";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return Problem("Rango inicial alcanzado");
            }
            Bitacora bitacora = new();
            bitacora.cod_registro = Guid.NewGuid().ToString();
            bitacora.date_registro = DateTime.Now;
            bitacora.tipo_registro = "Eliminar";
            bitacora.descripcion_registro = "Eliminar compra";
            bitacora.detalle_registro = compraTarjeta.ToString();
            _context.Bitacoras.Add(bitacora);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompraTarjetaExists(string id)
        {
            return (_context.ComprasTarjeta?.Any(e => e.num_tarjeta == id)).GetValueOrDefault();
        }
    }
}
