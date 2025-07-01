using CasaRositaFact.Data.Entities;

namespace CasaRositaFact.Data.IRepositories
{
    public interface IFacturaDetalleRepository
    {
        Task<IEnumerable<FacturaDetalle>> GetAllFacturaDetallesAsync();
        Task<FacturaDetalle> GetFacturaDetalleByIdAsync(int id);
        Task AddFacturaDetalleAsync(FacturaDetalle facturaDetalle);
        Task DeleteFacturaDetalleAsync(int id);
        Task UpdateFacturaDetalleAsync(FacturaDetalle facturaDetalle);
        Task<IEnumerable<FacturaDetalle>> GetFacturaDetallesByFacturaIdAsync(int facturaId);
    }
}
