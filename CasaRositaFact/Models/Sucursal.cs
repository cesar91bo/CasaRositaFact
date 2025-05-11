using System.ComponentModel.DataAnnotations;

namespace CasaRositaFact.Models
{
    public class Sucursal
    {
        [Key]
        public int IdSucursal { get; set; }
        [Required(ErrorMessage = "El nombre de la sucursal es obligatorio")]
        public required string Nombre { get; set; } = string.Empty;
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Observaciones { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public ICollection<Factura> Facturas { get; set; } = new List<Factura>();
    }
}
