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
    public class CompraEasyPaysController : ControllerBase
    {
        private readonly AeropuertoContext _context;

        public CompraEasyPaysController(AeropuertoContext context)
        {
            _context = context;
        }

        // GET: api/CompraEasyPays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompraEasyPay>>> GetComprasEasyPay()
        {
          if (_context.ComprasEasyPay == null)
          {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "404 Not Found";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return NotFound();
          }
            return await _context.ComprasEasyPay.ToListAsync();
        }

        // GET: api/CompraEasyPays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompraEasyPay>> GetCompraEasyPay(string id)
        {
          if (_context.ComprasEasyPay == null)
          {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "404 Not Found";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return NotFound();
          }
            var compraEasyPay = await _context.ComprasEasyPay.FindAsync(id);

            if (compraEasyPay == null)
            {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "404 Not Found";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return NotFound();
            }

            return compraEasyPay;
        }

        // PUT: api/CompraEasyPays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompraEasyPay(string id, CompraEasyPay compraEasyPay)
        {
            if (id != compraEasyPay.num_cuenta)
            {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "400 Bad Request";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return BadRequest();
            }

            _context.Entry(compraEasyPay).State = EntityState.Modified;

            try
            {
                Bitacora bitacora = new();
                bitacora.cod_registro = Guid.NewGuid().ToString();
                bitacora.date_registro = DateTime.Now;
                bitacora.tipo_registro = "Modificar";
                bitacora.descripcion_registro = "Modificar compra";
                bitacora.detalle_registro = compraEasyPay.ToString();
                _context.Bitacoras.Add(bitacora);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraEasyPayExists(id))
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

        // POST: api/CompraEasyPays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompraEasyPay>> PostCompraEasyPay(CompraEasyPay compraEasyPay)
        {
          if (_context.ComprasEasyPay == null)
          {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "Compras is null";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return Problem("Entity set 'AeropuertoContext.ComprasEasyPay'  is null.");
          }

            ConsecutivoHandler con = new();

            string nuevo_id = await con.GetId("4", _context);

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
                compraEasyPay.num_cuenta = nuevo_id;
            }
            _context.ComprasEasyPay.Add(compraEasyPay);
            try
            {
                Bitacora bitacora = new();
                bitacora.cod_registro = Guid.NewGuid().ToString();
                bitacora.date_registro = DateTime.Now;
                bitacora.tipo_registro = "Agregar";
                bitacora.descripcion_registro = "Agregar compra";
                bitacora.detalle_registro = compraEasyPay.ToString();
                _context.Bitacoras.Add(bitacora);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompraEasyPayExists(compraEasyPay.num_cuenta))
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

            return CreatedAtAction("GetCompraEasyPay", new { id = compraEasyPay.num_cuenta }, compraEasyPay);
        }

        // DELETE: api/CompraEasyPays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompraEasyPay(string id)
        {
            if (_context.ComprasEasyPay == null)
            {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "404 Not Found";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return NotFound();
            }
            var compraEasyPay = await _context.ComprasEasyPay.FindAsync(id);
            if (compraEasyPay == null)
            {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "404 Not Found";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return NotFound();
            }

            _context.ComprasEasyPay.Remove(compraEasyPay);
            ConsecutivoHandler con = new();
            string liberar = await con.LiberarConsecutivo("4", _context);
            if (liberar == null)
            {
                Error error = new();
                error.id_error = Guid.NewGuid().ToString();
                error.fecha_error = $"{DateTime.Now}";
                error.mensaje_error = "rango inicial alcanzado";
                _context.Errores.Add(error);
                await _context.SaveChangesAsync();
                return Problem("Rango inicial alcanzado");
            }
            Bitacora bitacora = new();
            bitacora.cod_registro = Guid.NewGuid().ToString();
            bitacora.date_registro = DateTime.Now;
            bitacora.tipo_registro = "Eliminar";
            bitacora.descripcion_registro = "Eliminar compra";
            bitacora.detalle_registro = compraEasyPay.ToString();
            _context.Bitacoras.Add(bitacora);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompraEasyPayExists(string id)
        {
            return (_context.ComprasEasyPay?.Any(e => e.num_cuenta == id)).GetValueOrDefault();
        }
    }
}
