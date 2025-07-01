using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;

namespace CasaRositaFact.Services
{
    public class FacturaDetalleService
    {
        private readonly IFacturaDetalleRepository _facturaDetalleRepository;
        public FacturaDetalleService(IFacturaDetalleRepository facturaDetalleRepository)
        {
            _facturaDetalleRepository = facturaDetalleRepository;
        }
        public Task<IEnumerable<FacturaDetalle>> GetAllFacturaDetallesAsync()
        {
            return _facturaDetalleRepository.GetAllFacturaDetallesAsync();
        }
        public Task<FacturaDetalle> GetFacturaDetalleByIdAsync(int id)
        {
            return _facturaDetalleRepository.GetFacturaDetalleByIdAsync(id);
        }
        public Task AddFacturaDetalleAsync(FacturaDetalle facturaDetalle)
        {
            return _facturaDetalleRepository.AddFacturaDetalleAsync(facturaDetalle);
        }
        public Task UpdateFacturaDetalleAsync(FacturaDetalle facturaDetalle)
        {
            return _facturaDetalleRepository.UpdateFacturaDetalleAsync(facturaDetalle);
        }
        public Task DeleteFacturaDetalleAsync(int id)
        {
            return _facturaDetalleRepository.DeleteFacturaDetalleAsync(id);
        }
        public Task<IEnumerable<FacturaDetalle>> GetFacturaDetallesByFacturaIdAsync(int facturaId)
        {
            return _facturaDetalleRepository.GetFacturaDetallesByFacturaIdAsync(facturaId);
        }
    }
}
