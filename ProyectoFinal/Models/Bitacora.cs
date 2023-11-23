using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ProyectoFinal.Models
{
    public class Bitacora
    {
        [Key]
        public string cod_registro {  get; set; } = null!;
        public DateTime date_registro { get; set; }
        public string tipo_registro { get; set; } = null!;
        public string descripcion_registro { get; set; } = null!;
        public string detalle_registro { get; set; } = null!;
        public Mantenimiento? Mantenimiento { get; set; }
    }
}
