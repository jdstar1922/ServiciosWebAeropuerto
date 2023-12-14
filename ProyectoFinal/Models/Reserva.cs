using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string num_reservacion { get; set; } = null!;
        public string booking_id { get; set; } = null!;
        public int cantidad_tkt { get; set; }
        public string mensaje_reserva { get; set; } = null !;
        public string Pago_Final { get; set; } = null!;
        public string id_usuario { get; set; } = null!;
        public Usuario? usuario { get; set; }
        public string? cod_vuelo { get; set; }
        public Vuelo? Vuelo { get; set; }
    }
}
