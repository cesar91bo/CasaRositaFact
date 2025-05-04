using CasaRositaFact.Models;

namespace CasaRositaFact.Data.IRepositories
{
    public interface IUnidadMedidaRepository
    {
        Task<IEnumerable<UnidadMedida>> GetAllUnidadMedidaAsync();
        Task<UnidadMedida?> GetUnidadMedidaByIdAsync(int id);
        Task AddUnidadMedidaAsync(UnidadMedida unidadMedida);
        Task UpdateUnidadMedidaAsync(UnidadMedida unidadMedida);
        Task DeleteUnidadMedidaAsync(int id);
    }
}
