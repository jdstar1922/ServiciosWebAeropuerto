using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_rol { get; set; } 
        public string nom_rol { get; set; } = null!;
        public ICollection<Usuario> usuarios { get; } = new List<Usuario>();
    }
}
