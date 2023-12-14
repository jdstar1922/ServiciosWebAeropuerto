using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class Bitacora
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string cod_registro {  get; set; } = null!;
        public DateTime date_registro { get; set; }
        public string tipo_registro { get; set; } = null!;
        public string descripcion_registro { get; set; } = null!;
        public string detalle_registro { get; set; } = null!;
        public Mantenimiento? Mantenimiento { get; set; }
    }
}
