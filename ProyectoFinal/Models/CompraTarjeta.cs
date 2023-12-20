using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ProyectoFinal.Models
{
    public class CompraTarjeta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string num_tarjeta { get; set; } = null!;
        public DateTime fecha_expiracion { get; set; }
        public string cvv_tarjeta { get; set; } = null!;
        public string id_usuario { get; set; } = null!;
        public Usuario? Usuario { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
