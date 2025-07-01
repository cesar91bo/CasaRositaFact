using System.ComponentModel.DataAnnotations;

namespace CasaRositaFact.Data.Entities
{
    public class RegimenImpositivo
    {
        [Key]
        public int IdRegimenImpositivo { get; set; }
        public required string Descripcion { get; set; }
    }
}
