using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class Consecutivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string id_consecutivo {  get; set; } = null!;
        public string descripcion_consecutivo { get; set; } = null!;
        public string prefijo_consecutivo { get; set; } = null!;   
        public string rango_Inicial { get; set; } = null!;
        public string rango_Final { get; set; } = null!;       
        public int valor_consecutivo { get; set; }

        public Mantenimiento? Mantenimiento { get; set; }
    }
}
