using System.ComponentModel.DataAnnotations;

namespace CasaRositaFact.Models
{
    public class Rubro
    {
        [Key]
        public int IdRubro { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();
    }
}
