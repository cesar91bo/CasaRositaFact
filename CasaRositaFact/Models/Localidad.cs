using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasaRositaFact.Models
{
    public class Localidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdLocalidad { get; set; }
        public int IdProvincia { get; set; }
        public string Nombre { get; set; } = string.Empty;
        [ForeignKey("IdProvincia")]
        public Provincia Provincia { get; set; } = new Provincia();
    }
}
