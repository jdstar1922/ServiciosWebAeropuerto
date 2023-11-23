using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.ModelsBanco
{
    public class Cuenta
    {
        [Key]
        public string num_cuenta { get; set; } = null!;
        public string tipo_cuenta { set; get; } = null!;
        public string cantidad_dinero { get; set; } = null!;
        public string id_movimientos { get; set; } = null!;
        public Transaccion Transaccion { get; set; } = null!;
    }
}
