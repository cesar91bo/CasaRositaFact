using System.ComponentModel.DataAnnotations;

namespace CasaRositaFact.Models
{
    public class ConceptoFactura
    {
        [Key]
        public int IdConceptoFactura { get; set; }
        [Required(ErrorMessage = "El nombre del concepto de la factura es obligatorio")]
        public required string Nombre { get; set; } = string.Empty;

        public ICollection<Factura> Facturas { get; set; } = new List<Factura>();
    }
}
