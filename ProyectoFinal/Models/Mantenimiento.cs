using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace ProyectoFinal.Models
{
    public class Mantenimiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = null!;
        public string id_error { get; set; } = null!;
        public Error? Error { get; set; }
        public string id_consecutivo { get; set; } = null!;
        public Consecutivo? Consecutivo { get; set; }
        public string cod_registro { get; set; } = null!;
        public Bitacora? Bitacora { get; set; }
        public string descripcion_mantenimiento { get; set; } = null!;
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
