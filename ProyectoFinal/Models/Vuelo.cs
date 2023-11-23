using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Vuelo
    {
        [Key]
        public string cod_vuelo { get; set; } = null!;
        public DateTime fecha_vuelo { get; set; }
        public int estado_vuelo { get; set; }
        public string nom_estadoV { get; set; } = null!;
        public string cod_puerta { get; set; } = null!;
        public Puerta puerta { get; set; } = null!;
        public string id_aerolinea { get; set; } = null!;
        public Aerolinea Aerolinea { get; set; } = null!;
        public string id_pais { get; set; } = null!;
        public Pais Pais { get; set; } = null!;
        public string id_usuario { get; set; } = null!;
        public Usuario Usuario { get; set;} = null!;
    }
}
