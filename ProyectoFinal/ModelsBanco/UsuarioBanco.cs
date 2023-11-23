using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.ModelsBanco
{
    public class UsuarioBanco
    {
        [Key]
        public string Cedula_usuario { get; set; } = null!;
        public string nom_usuario { get; set; } = null!;
        public string pri_apellido { get; set; } = null!;
        public string seg_apellido { get; set; } = null!;
        public string correo { get; set; } = null!;
    }
}
