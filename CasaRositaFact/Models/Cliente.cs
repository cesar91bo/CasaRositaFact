
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasaRositaFact.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public required string Nombre { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public required string Apellido { get; set; }
        public string Documento { get; set; } = string.Empty;
        [Required(ErrorMessage = "El tipo de documento es obligatorio")]
        public required int IdTipoDocumento { get; set; }
        public string? CUIT { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Localidad { get; set; } = string.Empty;
        public string Provincia { get; set; } = string.Empty;
        public string CodigoPostal { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string CorreoElectronico { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public DateTime? FechaBaja { get; set; }
        [Required(ErrorMessage = "El régimen impositivo es obligatorio")]
        public required int IdRegimenImpositivo { get; set; }
        public enum EstadoCliente { Activo, Inactivo, Suspendido }
        public EstadoCliente Estado { get; set; } = EstadoCliente.Activo;
        public string Observaciones { get; set; } = string.Empty;
        public RegimenImpositivo RegimenImpositivo { get; set; } = null!;
        public TipoDocumento TipoDocumento { get; set; } = null!;
        [NotMapped]
        public string NombreCompleto
        {
            get => $"{Nombre} {Apellido}";
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    var partes = value.Split(' ', 2); // Solo divide en dos
                    Nombre = partes[0];
                    Apellido = partes.Length > 1 ? partes[1] : "";
                }
            }
        }

        public ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    }
}
