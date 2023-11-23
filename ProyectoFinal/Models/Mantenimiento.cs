using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace ProyectoFinal.Models
{
    public class Mantenimiento
    {
        [Key]
        public string Id { get; set; } = null!;
        public string id_error { get; set; } = null!;
        public Error Error { get; set; } = null!;
        public string id_consecutivo { get; set; } = null!;
        public Consecutivo Consecutivo { get; set; } = null!;
        public string cod_registro { get; set; } = null!;
        public Bitacora? Bitacora { get; set; }
        public string descripcion_mantenimiento { get; set; } = null!;
    }
}
