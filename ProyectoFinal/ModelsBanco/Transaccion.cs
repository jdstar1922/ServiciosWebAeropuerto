using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.ModelsBanco
{
    public class Transaccion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string id_movimientos { get; set; } = null!;
        public string nom_movimientos { get; set; } = null!;
        public decimal cantidad_enviada { get; set; }
        public string num_cuenta { get; set; } = null!;
        public Cuenta? Cuenta { get; set; }
    }
}
