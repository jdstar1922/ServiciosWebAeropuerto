using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ProyectoFinal.Models
{
    public class Aerolinea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string id_aerolinea { get; set; } = null!;
        public string nom_aerolinea {  set; get; } = null!;
        public string logo_aerolinea { set; get;} = null!;
        public string? cod_agencia { set; get; }
        public Agencia? Agencia { set;  get; }
        public string? id_pais { set; get; }
        
        public Pais? Pais { set;  get; }
        public ICollection<Puerta> Puertas { get; } = new List<Puerta>();
        public ICollection<Vuelo> Vuelos { get; } = new List<Vuelo>();
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
