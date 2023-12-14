using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.ModelsBanco
{
    public class Cuenta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string num_cuenta { get; set; } = null!;
        public string tipo_cuenta { set; get; } = null!;
        public string cantidad_dinero { get; set; } = null!;
        public UsuarioBanco? UsuarioBanco { get; set; }
        public ICollection<Transaccion> Transaccions { get; } = new List<Transaccion>();
    }
}
