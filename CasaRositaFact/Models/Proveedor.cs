using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasaRositaFact.Models
{
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }
        [Required(ErrorMessage ="El nombre o razón social del proveedor es obligatorio")]
        public required string RazonSocial { get; set; } = string.Empty;
        public string? CUIT { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? NombreContacto { get; set; }
        public int? IdBanco { get; set; } //Banco del proveedor
        public string? CBU { get; set; } //CBU del proveedor
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public DateTime? FechaBaja { get; set; }
        public enum EstadoProveedor { Activo, Inactivo, Suspendido }
        public EstadoProveedor Estado { get; set; } = EstadoProveedor.Activo;
        public string? Observaciones { get; set; }

        [ForeignKey("IdBanco")]
        public Banco? Banco { get; set; } //Banco del proveedor
        public ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();
    }
}
