using System.ComponentModel.DataAnnotations;

namespace CasaRositaFact.Models
{
    public class LetraFactura
    {
        [Key]
        public int IdLetraFactura { get; set; }
        public required string Nombre { get; set; } = string.Empty;

        public ICollection<Factura> Facturas { get; set; } = new List<Factura>();
    }
}
