using CasaRositaFact.Data.Entities;

namespace CasaRositaFact.Data.IRepositories
{
    public interface IFacturaRepository 
    {
        Task<IEnumerable<Factura>> GetAllFacturasAsync();
        Task<Factura> GetFacturaByIdAsync(int id);
        Task AddFacturaAsync(Factura factura);
        Task DeleteFacturaAsync(int id);
        Task UpdateFacturaAsync(Factura factura);
        Task<IEnumerable<Factura>> GetFacturasByClienteIdAsync(int clienteId);
        Task<IEnumerable<Factura>> GetFacturasByFechaAsync(DateTime fecha);
        Task<IEnumerable<Factura>> GetFacturasByRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin);
        Task <bool>AnularFacturaAsync(int idFactura, int idUsuario);
    }
}
