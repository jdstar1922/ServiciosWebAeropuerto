using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Puerta
    {
        [Key]
        public string cod_puerta { get; set; } = null!;
        public string num_puerta {  set; get; } = null!;
        public string detalle_puerta { set; get;} = null!;
        public int estado_puerta { set; get; }
        public string nom_estadoP {  set; get; } = null!;
        public string id_aerolinea { set; get; } = null!;
        public Aerolinea Aerolinea { get; set; } = null!;
        public ICollection<Vuelo> vuelo { set; get; } = null!;
    }
}
