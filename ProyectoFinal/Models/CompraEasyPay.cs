using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ProyectoFinal.Models
{
    public class CompraEasyPay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string num_cuenta { get; set; } = null!;
        public string cod_seguridad { get; set; } = null!;
        public string contra_easy { get; set; } = null!;
        public string id_usuario { get; set; } = null!;
        public Usuario? usuario { get; set;}
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
