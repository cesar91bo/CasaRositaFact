using System.ComponentModel.DataAnnotations;

namespace CasaRositaFact.Data.Entities
{
    public class TipoDocumento
    {
        [Key]
        public int IdTipoDocumento { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        public List<Cliente> Clientes { get; set; } = new ();
    }
}
