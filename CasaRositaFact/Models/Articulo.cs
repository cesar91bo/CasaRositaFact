using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasaRositaFact.Models
{
    public class Articulo
    {
        [Key]
        public int IdArticulo { get; set; }
        [Required(ErrorMessage ="El nombre del artículo es obligatorio")]
        public required string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int? IdCategoria { get; set; } //Electrónica, Ropa, Alimentos
        public int? IdRubro { get; set; } //Ferretería, Librería, Farmacia
        public bool LlevarStock { get; set; } = false;
        [Precision(18,2)]
        public decimal? StockActual { get; set; }
        public DateTime? FechaUltimoIngreso { get; set; }
        [Precision(18, 2)]
        public decimal? CantidadMinima { get; set; }
        public int? IdUnidadMedida { get; set; } //Kg, L, m, cm
        public DateTime? FechaBaja { get; set; }
        public string? CodigoProducto { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public int? IdProveedor { get; set; } //Proveedor del artículo

        [NotMapped]
        public decimal? PrecioActual { get; set; }

        [ForeignKey("IdCategoria")]
        public Categoria? Categoria { get; set; }
        [ForeignKey("IdRubro")]
        public Rubro? Rubro { get; set; }
        [ForeignKey("IdUnidadMedida")]
        public UnidadMedida? UnidadMedida { get; set; }
        [ForeignKey("IdProveedor")]
        public Proveedor? Proveedor { get; set; }
        public string ImagenPath { get; set; } = string.Empty;

        public ICollection<PrecioArticulo> PreciosArticulos { get; set; } = new List<PrecioArticulo>();
        public ICollection<FacturaDetalle> FacturaDetalles { get; set; } = new List<FacturaDetalle>();
    }
}
