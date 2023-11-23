using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Agencia
    {
        [Key]
        public string cod_agencia { get; set; } = null!;
        public string nom_agencia { get; set; } = null!;
        public string logo_agencia { get; set; } = null!;
        public string? id_pais { get; set; }
        public Pais? Pais { get; set; }
    }
}
