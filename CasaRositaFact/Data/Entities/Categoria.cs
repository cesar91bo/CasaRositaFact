using System.ComponentModel.DataAnnotations;

namespace CasaRositaFact.Data.Entities
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();
    }
}
