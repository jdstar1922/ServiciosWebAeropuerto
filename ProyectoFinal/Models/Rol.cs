using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Rol
    {
        [Key]
        public int id_rol { get; set; } 
        public string nom_rol { get; set; } = null!;
        public ICollection<Usuario>? usuarios { get; }
    }
}
