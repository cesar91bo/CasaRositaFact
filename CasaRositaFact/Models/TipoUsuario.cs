using System.ComponentModel.DataAnnotations;

namespace CasaRositaFact.Models
{
    public class TipoUsuario
    {
        [Key]
        public int IdTipoUsuario { get; set; }
        [Required(ErrorMessage = "El nombre del tipo de usuario es obligatorio")]
        public required string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
