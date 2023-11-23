using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Aerolinea
    {
        [Key]
        public string id_aerolinea { get; set; } = null!;
        public string nom_aerolinea {  set; get; } = null!;
        public string logo_aerolinea { set; get;} = null!;
        public string? cod_agencia { set; get; }
        public Agencia? Agencia { set;  get; }
        public string? id_pais { set; get; }
        
        public Pais? Pais { set;  get; }
        public ICollection<Puerta> Puertas { get; } = null!;
        public ICollection<Vuelo> Vuelos { get; } = null!;
    }
}
