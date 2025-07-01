using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasaRositaFact.Data.Entities
{
    public class Factura
    {
        [Key]
        public int IdFactura { get; set; }
        public required int IdTipoDocumentoFiscal { get; set; } //Tipo de documento: Factura, Ticket, Nota de crédito, etc.
        public required int IdLetraFactura { get; set; }
        public string? BVFactura { get; set; } //Boca de venta
        public string? NroCompFactura { get; set; } //Número de factura
        public DateTime FechaEmision { get; set; }
        public int IdFormaPago { get; set; }
        public int IdCliente { get; set; }
        public bool Impresa { get; set; } = false;
        public string? Observaciones { get; set; }
        [Precision(18, 2)]
        public decimal? SubTotal105 { get; set; }
        [Precision(18, 2)]
        public decimal? SubTotal21 { get; set; }
        [Precision(18, 2)]
        public decimal SubTotal { get; set; }
        [Precision(4, 2)]
        public decimal? Descuento { get; set; }
        [Precision(18, 2)]
        public decimal? TotalDescuento105 { get; set; }
        [Precision(18, 2)]
        public decimal? TotalDescuento21 { get; set; }
        [Precision(18, 2)]
        public decimal TotalDescuento { get; set; }
        [Precision(18, 2)]
        public decimal? TotalIva105 { get; set; }
        [Precision(18, 2)]
        public decimal? TotalIva21 { get; set; }
        [Precision(18, 2)]
        public decimal Total { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public bool Anulada { get; set; } = false;
        public int? IdUsuario { get; set; } //Usuario que generó la factura
        public DateTime? FechaAnulacion { get; set; }
        public int? IdUsuarioAnulacion { get; set; } //Usuario que anuló la factura
        [Precision(18, 2)]
        public decimal? TotalSaldando { get; set; }
        [Precision(18, 2)]
        public decimal? TotalInteres { get; set; }
        [Precision(18, 2)]
        public decimal? TotalInteresSaldando { get; set; }
        public int IdEmpresa { get; set; } //Empresa a la que pertenece la factura
        public int? IdSucursal { get; set; } //Sucursal a la que pertenece la factura
        public string? BVReferencia { get; set; } //Boca de venta de referencia
        public string? NroCompReferencia { get; set; } //Número de factura de referencia
        public int IdConceptoFactura { get; set; } //Concepto de la factura: Venta, Devolución, etc.
        public bool MoverStock { get; set; } = false; //Indica si se debe mover el stock al generar la factura
        [StringLength(50)]
        public string? NombreMaquina { get; set; } //Nombre de la máquina desde donde se generó la factura

        [ForeignKey("IdTipoDocumentoFiscal")]
        public TipoDocumentoFiscal? TipoDocumentoFiscal { get; set; }
        [ForeignKey("IdLetraFactura")]
        public LetraFactura? LetraFactura { get; set; }
        [ForeignKey("IdFormaPago")]
        public FormaPago? FormaPago { get; set; }
        [ForeignKey("IdCliente")]
        public Cliente? Cliente { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario? UsuarioGenerador { get; set; }
        [ForeignKey("IdUsuarioAnulacion")]
        public Usuario? UsuarioAnulador { get; set; }
        [ForeignKey("IdConceptoFactura")]
        public ConceptoFactura? ConceptoFactura { get; set; }
        [ForeignKey("IdEmpresa")]
        public Empresa? Empresa { get; set; }
        [ForeignKey("IdSucursal")]
        public Sucursal? Sucursal { get; set; }

        public ICollection<FacturaDetalle> Detalles { get; set; } = new List<FacturaDetalle>();
    }
}
