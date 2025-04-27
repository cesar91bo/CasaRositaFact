
using System.ComponentModel.DataAnnotations;

namespace CasaRositaFact.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public string Documento { get; set; } = string.Empty;
        public string TipoDocumento { get; set; } = string.Empty;
        public string CUIT { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Localidad { get; set; } = string.Empty;
        public string Provincia { get; set; } = string.Empty;
        public string CodigoPostal { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string CorreoElectronico { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public DateTime? FechaBaja { get; set; }
        public int IdRegimenImpositivo { get; set; }
        public enum EstadoCliente { Activo, Inactivo, Suspendido }
        public EstadoCliente Estado { get; set; } = EstadoCliente.Activo;
        public string Observaciones { get; set; } = string.Empty;
        public RegimenesImpositivos? RegimenImpositivo { get; set; } = null;

    }
}
