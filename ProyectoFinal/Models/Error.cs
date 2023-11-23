using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Error
    {
        [Key]
        public string id_error {  get; set; } = null!;
        public string fecha_error { get; set; } = null!;
        public string mensaje_error { get; set; } = null!;
        public Mantenimiento Mantenimiento { get; set; } = null!;
    }
}
