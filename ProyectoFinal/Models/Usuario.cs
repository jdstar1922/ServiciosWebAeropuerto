using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Usuario
    {
        [Key]
        public string id_usuario {  get; set; } = null!;
        public string nom_usuario { get; set; } = null!;
        public string pri_apellido { get; set; } = null!;
        public string seg_apellido { get; set; } = null!;
        public string correo_usuario { get; set; } = null!;
        public string contra_usuario { get; set; } = null!;
        public string pregunta_seguridad { get; set; } = null!;
        public string respuesta_seguridad { get; set; } = null!;
        public int id_rol { get; set;}
        public Rol Rol { get; set; } = null!;
        public ICollection<Vuelo> Vuelos { get; set; } = null!;
        public ICollection<Reserva> Reservas { get; set; } = null!; 
        public ICollection<CompraEasyPay> CompraEasyPays { get; set; } = null!;
        public ICollection<CompraTarjeta> CompraTarjetas { get; set; } = null!;
    }
}
