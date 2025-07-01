using System.ComponentModel.DataAnnotations;

namespace CasaRositaFact.Data.Entities
{
    public class Banco
    {
        [Key]
        public int IdBanco { get; set; }
        [Required(ErrorMessage = "El nombre del banco es obligatorio")]
        public required string Nombre { get; set; } = string.Empty;

        public ICollection<Proveedor> Proveedores { get; set; } = new List<Proveedor>();
    }
}
