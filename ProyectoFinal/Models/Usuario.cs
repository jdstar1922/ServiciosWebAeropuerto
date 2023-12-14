using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string id_usuario {  get; set; } = null!;
        public string nom_usuario { get; set; } = null!;
        public string pri_apellido { get; set; } = null!;
        public string seg_apellido { get; set; } = null!;
        public string correo_usuario { get; set; } = null!;
        public string contra_usuario { get; set; } = null!;
        public string pregunta_seguridad { get; set; } = null!;
        public string respuesta_seguridad { get; set; } = null!;
        public int id_rol { get; set;}
        public Rol? Rol { get; set; }
        public ICollection<Vuelo> Vuelos { get; set; } = new List<Vuelo>();
        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>(); 
        public ICollection<CompraEasyPay> CompraEasyPays { get; set; } = new List<CompraEasyPay>();
        public ICollection<CompraTarjeta> CompraTarjetas { get; set; } = new List<CompraTarjeta>();
    }
}
