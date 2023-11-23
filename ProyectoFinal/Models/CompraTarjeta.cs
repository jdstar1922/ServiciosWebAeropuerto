using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class CompraTarjeta
    {
        [Key]
        public string num_tarjeta { get; set; } = null!;
        public DateTime fecha_expiracion { get; set; }
        public string cvv_tarjeta { get; set; } = null!;
        public string id_usuario { get; set; } = null!;
        public Usuario Usuario { get; set; } = null !;
    }
}
