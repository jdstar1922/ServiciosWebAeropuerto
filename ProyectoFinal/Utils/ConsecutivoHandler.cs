using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinal.Utils
{
    public class ConsecutivoHandler
    {
        public async Task<string> GetId(string id, AeropuertoContext _context)
        {
            
            Consecutivo consecutivo = await _context.Consecutivos.FindAsync(id);

            if (consecutivo.valor_consecutivo < Int32.Parse(consecutivo.rango_Final))
            {
                string nuevo_id = $"{consecutivo.prefijo_consecutivo}{consecutivo.valor_consecutivo}";
                consecutivo.valor_consecutivo += 1;
                _context.Entry(consecutivo).State = EntityState.Modified;
                return nuevo_id;
            }
            else

            {
                return "";
            }
        }
        public async Task<string> LiberarConsecutivo(string id, AeropuertoContext _context)
        {

            Consecutivo consecutivo = await _context.Consecutivos.FindAsync(id);
            if (consecutivo.valor_consecutivo == Int32.Parse(consecutivo.rango_Inicial)) {
                consecutivo.valor_consecutivo -= 1;
                _context.Entry(consecutivo).State = EntityState.Modified;
                return "Consecutivo liberado";
            } else
            {
                return "";
            }
            
        }
    }
}
