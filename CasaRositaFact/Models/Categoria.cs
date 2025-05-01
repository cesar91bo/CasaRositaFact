using System.ComponentModel.DataAnnotations;

namespace CasaRositaFact.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();
    }
}
