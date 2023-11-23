using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.ModelsBanco
{
    public class Transaccion
    {
        [Key]
        public string id_movimientos { get; set; } = null!;
        public string nom_movimientos { get; set; } = null!;
        public decimal cantidad_enviada { get; set; }
    }
}
