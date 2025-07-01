using System.ComponentModel.DataAnnotations.Schema;

namespace CasaRositaFact.Data.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string? ClaveUsuario { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public DateTime? FechaUltimoAcceso { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime? FechaBaja { get; set; }
        public int? IdSucursal { get; set; } //Sucursal a la que pertenece el usuario


        [ForeignKey("IdTipoUsuario")]
        public TipoUsuario? TiposUsuarios { get; set; }
        [ForeignKey("IdSucursal")]
        public Sucursal? Sucursal { get; set; } //Sucursal a la que pertenece el usuario
        public ICollection<Factura> FacturasGeneradas { get; set; } = new List<Factura>();
        public ICollection<Factura> FacturasAnuladas { get; set; } = new List<Factura>();


    }
}
