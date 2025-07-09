using CasaRositaFact.Data.Entities;

namespace CasaRositaFact.State
{
    public class FacturaState
    {
        public Factura? FacturaActual { get; set; }

        public void Limpiar()
        {
            FacturaActual = null;
        }
    }
}
