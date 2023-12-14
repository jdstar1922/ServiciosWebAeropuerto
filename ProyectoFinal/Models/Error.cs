using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class Error
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string id_error {  get; set; } = null!;
        public string fecha_error { get; set; } = null!;
        public string mensaje_error { get; set; } = null!;
        public Mantenimiento? Mantenimiento { get; set; }
    }
}
