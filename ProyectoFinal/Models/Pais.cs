using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class Pais
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string id_pais { get; set; } = null!;
        public string nom_pais { get; set; } = null!;
        public string bandera_pais { get; set; } = null!;
        public ICollection<Agencia> Agencias { get;} = new List<Agencia>();
        public ICollection<Aerolinea>? Aerolineas { get;} = new List<Aerolinea>();
        public ICollection<Vuelo> Vuelos { get;} = new List<Vuelo>();
    }
}
