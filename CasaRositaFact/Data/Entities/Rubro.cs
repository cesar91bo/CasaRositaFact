using System.ComponentModel.DataAnnotations;

namespace CasaRositaFact.Data.Entities
{
    public class Rubro
    {
        [Key]
        public int IdRubro { get; set; }
        [Required(ErrorMessage = "El nombre del rubro es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();
    }
}
