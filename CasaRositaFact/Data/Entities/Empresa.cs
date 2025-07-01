using System.ComponentModel.DataAnnotations;

namespace CasaRositaFact.Data.Entities
{
    public class Empresa
    {
        [Key]
        public int IdEmpresa { get; set; }
        public string? RazonSocial { get; set; }
        public string? NombreFantasia { get; set; }
        public string? Cuit { get; set; }
        public string? Domicilio { get; set; }
        public DateTime? InicioActividad { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? IIBB { get; set; }
        public string? CondicionIva { get; set; } //IVA Responsable Inscripto, IVA Responsable No Inscripto, IVA Exento, IVA No Alcanzado
        public int? CodigoPostal { get; set; }
        public string? RutaCertificado { get; set; }
        public string? SerieCertificado { get; set; }
        public DateTime? FechaExpiracionCertificado { get; set; }

        public Parametro Parametro { get; set; } = new Parametro();
    }
}
