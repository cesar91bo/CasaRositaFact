using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasaRositaFact.Models
{
    public class UnidadMedida
    {
        [Key]
        public int IdUnidadMedida { get; set; }
        [Required(ErrorMessage = "El nombre de unidad de medida es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        // Relación con Articulo
        public ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();
    }
}
