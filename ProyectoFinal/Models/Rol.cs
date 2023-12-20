using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ProyectoFinal.Models
{
    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_rol { get; set; } 
        public string nom_rol { get; set; } = null!;
        public ICollection<Usuario> usuarios { get; } = new List<Usuario>();
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
