using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ProyectoFinal.Models
{
    public class Puerta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string cod_puerta { get; set; } = null!;
        public string num_puerta {  set; get; } = null!;
        public string detalle_puerta { set; get;} = null!;
        public int estado_puerta { set; get; }
        public string nom_estadoP {  set; get; } = null!;
        public string id_aerolinea { set; get; } = null!;
        public Aerolinea? Aerolinea { get; set; }
        public ICollection<Vuelo> vuelo { set; get; } = new List<Vuelo>();
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
