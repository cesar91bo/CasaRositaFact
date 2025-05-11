using System.ComponentModel.DataAnnotations;

namespace CasaRositaFact.Models
{
    public class FormaPago
    {
        [Key]
        public int IdFormaPago { get; set; }
        public required string Nombre { get; set; }

        public ICollection<Factura> Facturas { get; set; } = new List<Factura>();
    }
}
