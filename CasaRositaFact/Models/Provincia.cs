using System.ComponentModel.DataAnnotations;

namespace CasaRositaFact.Models
{
    public class Provincia
    {
        [Key]
        public int IdProvincia { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Localidad> Localidades { get; set; } = new List<Localidad>();
    }
}
