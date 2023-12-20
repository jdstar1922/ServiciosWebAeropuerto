using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ProyectoFinal.Models
{
    public class Agencia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string cod_agencia { get; set; } = null!;
        public string nom_agencia { get; set; } = null!;
        public string logo_agencia { get; set; } = null!;
        public string? id_pais { get; set; }
        public Pais? Pais { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
