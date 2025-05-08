using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasaRositaFact.Models
{
    public class Parametro
    {
        [Key, ForeignKey("Empresa")]
        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; set; } = new Empresa();
        [Precision(4, 1)]
        public decimal PorcentajeGanancia { get; set; }
        public DateTime? FechaVtoFactura { get; set; }
        public int? CantidadMaxItemFactura { get; set; }
        public string? ImpresoraPredeterminada { get; set; }
    }
}
