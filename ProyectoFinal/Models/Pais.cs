using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Pais
    {
        [Key]
        public string id_pais { get; set; } = null!;
        public string nom_pais { get; set; } = null!;
        public string bandera_pais { get; set; } = null!;
        public ICollection<Agencia> Agencias { get;} = null!;
        public ICollection<Aerolinea>? Aerolineas { get;}
        public ICollection<Vuelo> Vuelos { get;} = null!;
    }
}
