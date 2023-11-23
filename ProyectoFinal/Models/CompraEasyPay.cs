using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class CompraEasyPay
    {
        [Key]
        public string num_cuenta { get; set; } = null!;
        public string cod_seguridad { get; set; } = null!;
        public string contra_easy { get; set; } = null!;
        public string id_usuario { get; set; } = null!;
        public Usuario usuario { get; set;} = null!;
    }
}
