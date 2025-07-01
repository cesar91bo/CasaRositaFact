using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;

namespace CasaRositaFact.Services
{
    public class FacturaService
    {
        public readonly IFacturaRepository _facturaRepository;
        public FacturaService(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }
        public Task<IEnumerable<Factura>> GetAllFacturasAsync()
        {
            return _facturaRepository.GetAllFacturasAsync();
        }
        public Task<Factura> GetFacturaByIdAsync(int id)
        {
            return _facturaRepository.GetFacturaByIdAsync(id);
        }
        public Task AddFacturaAsync(Factura factura)
        {
            return _facturaRepository.AddFacturaAsync(factura);
        }
        public Task UpdateFacturaAsync(Factura factura)
        {
            return _facturaRepository.UpdateFacturaAsync(factura);
        }
        public Task DeleteFacturaAsync(int id)
        {
            return _facturaRepository.DeleteFacturaAsync(id);
        }
        public Task<IEnumerable<Factura>> GetFacturasByClienteIdAsync(int clienteId)
        {
            return _facturaRepository.GetFacturasByClienteIdAsync(clienteId);
        }
        public Task<IEnumerable<Factura>> GetFacturasByFechaAsync(DateTime fecha)
        {
            return _facturaRepository.GetFacturasByFechaAsync(fecha);
        }
        public Task<IEnumerable<Factura>> GetFacturasByRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            return _facturaRepository.GetFacturasByRangoFechasAsync(fechaInicio, fechaFin);
        }

        public async Task<bool> AnularFacturaAsync(int idFactura, int idUsuario)
        {
            return await _facturaRepository.AnularFacturaAsync(idFactura, idUsuario);
        }
    }

}
