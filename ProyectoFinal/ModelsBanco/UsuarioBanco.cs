using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.ModelsBanco
{
    public class UsuarioBanco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Cedula_usuario { get; set; } = null!;
        public string nom_usuario { get; set; } = null!;
        public string pri_apellido { get; set; } = null!;
        public string seg_apellido { get; set; } = null!;
        public string correo { get; set; } = null!;
        public string num_cuenta { get; set; } = null!;
        public Cuenta? Cuenta { get; set; }
    }
}
