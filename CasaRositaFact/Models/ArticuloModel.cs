namespace CasaRositaFact.Models
{
    public class ArticuloModel
    {
        public int IdArticulo { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal? StockActual { get; set; }
        public decimal PrecioActual { get; set; }
    }
}
