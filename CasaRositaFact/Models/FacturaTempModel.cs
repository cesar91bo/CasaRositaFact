using CasaRositaFact.Data.Entities;

namespace CasaRositaFact.Models
{
    public class FacturaTempModel
    {
        public Factura Factura { get; set; } = default!;
        public List<FacturaDetalle> Detalles { get; set; } = new();
    }
}
