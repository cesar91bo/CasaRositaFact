using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasaRositaFact.Data.Entities
{
    public class PrecioArticulo
    {
        [Key]
        public int IdPrecioArticulo { get; set; }
        public int IdArticulo { get; set; }
        [Precision(18, 2)]
        public required decimal PrecioVentaSinIva { get; set; }
        [Precision(18, 2)]
        public required decimal PrecioVentaConIva { get; set; }
        [Precision(18, 2)]
        public required decimal PrecioCosto { get; set; }
        [Precision(18, 2)]
        public decimal PrecioLista { get; set; }
        [Precision(18, 2)]
        public decimal PrecioDescuento { get; set; }
        [Precision(4,1)]
        public decimal PorcentajeGanancia { get; set; }
        [Column("IdTipoIva")]
        public int? IdTipoIva { get; set; } //IVA 21%, IVA 10.5%, IVA 27%
        public DateTime FechaIncio { get; set; } = DateTime.Now;
        public DateTime? FechaUltimaActualizacion { get; set; }
        public bool EsPrecioPublico { get; set; } = false;
        public bool EsPrecioCosto { get; set; } = false;
        public bool EsPrecioLista { get; set; } = false;
        public bool EsPrecioDescuento { get; set; } = false;

        [ForeignKey("IdArticulo")]
        public Articulo? Articulo { get; set; }

        [ForeignKey("IdTipoIva")]
        public TipoIva? TipoIva { get; set; }

    }
}