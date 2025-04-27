using System.ComponentModel.DataAnnotations;

namespace CasaRositaFact.Models
{
    public class RegimenesImpositivos
    {
        [Key]
        public int IdRegimenImpositivo { get; set; }
        public required string Descripcion { get; set; }
    }
}
