using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasaRositaFact.Data.Entities
{
    public class FacturaDetalle
    {
        [Key]
        public int IdFacturaDetalle { get; set; }
        public int IdFactura { get; set; }
        public int IdArticulo { get; set; }
        public string? NombreArticulo { get; set; } //Nombre del artículo
        public int IdUnidadMedida { get; set; } //Unidad de medida del artículo
        [Precision(6, 2)]
        public decimal Cantidad { get; set; }
        [Precision(18, 2)]
        public decimal PrecioUnitario { get; set; }
        public int? IdTipoIva { get; set; } //Tipo de IVA del artículo
        [Precision(18, 2)]
        public decimal? TotalArticulo { get; set; }
        public bool? DesdeRemito { get; set; } = false; //Indica si el detalle se generó desde un remito
        public int? IdRemito { get; set; } //Id del remito desde el cual se generó el detalle
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public int? IdUsuario { get; set; } //Usuario que generó el detalle
        public DateTime? FechaBaja { get; set; } //Fecha de baja del detalle
        public bool? PrecioManual { get; set; } = false; //Indica si el precio fue modificado manualmente

        [ForeignKey("IdFactura")]
        public Factura Factura { get; set; } = null!; //Factura a la que pertenece el detalle
        [ForeignKey("IdArticulo")]
        public Articulo Articulo { get; set; } = null!; //Artículo al que pertenece el detalle
        [ForeignKey("IdUnidadMedida")]
        public UnidadMedida UnidadMedida { get; set; } = null!; //Unidad de medida del artículo
        [ForeignKey("IdTipoIva")]
        public TipoIva? TipoIva { get; set; } //Tipo de IVA del artículo
        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; } //Usuario que generó el detalle
    }
}
