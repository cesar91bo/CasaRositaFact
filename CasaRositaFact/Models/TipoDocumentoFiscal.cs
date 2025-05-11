using System.ComponentModel.DataAnnotations;

namespace CasaRositaFact.Models
{
    public class TipoDocumentoFiscal
    {
        [Key]
        public int IdTipoDocumentoFiscal { get; set; }
        [Required(ErrorMessage = "El nombre del tipo de documento fiscal es obligatorio")]
        public required string Nombre { get; set; }

        public ICollection<Factura> Facturas { get; set; } = new List<Factura>();
    }
}
