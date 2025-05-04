using CasaRositaFact.Data.IRepositories;
using CasaRositaFact.Models;

namespace CasaRositaFact.Services
{
    public class UnidadMedidaService
    {
        private readonly IUnidadMedidaRepository _unidadMedidaRepository;
        public UnidadMedidaService(IUnidadMedidaRepository unidadMedidaRepository)
        {
            _unidadMedidaRepository = unidadMedidaRepository;
        }
        public Task<IEnumerable<UnidadMedida>> GetAllUnidadMedidaAsync()
        {
            return _unidadMedidaRepository.GetAllUnidadMedidaAsync();
        }
        public Task<UnidadMedida?> GetUnidadMedidaByIdAsync(int id)
        {
            return _unidadMedidaRepository.GetUnidadMedidaByIdAsync(id);
        }
        public Task AddUnidadMedidaAsync(UnidadMedida unidadMedida)
        {
            return _unidadMedidaRepository.AddUnidadMedidaAsync(unidadMedida);
        }
        public Task UpdateUnidadMedidaAsync(UnidadMedida unidadMedida)
        {
            return _unidadMedidaRepository.UpdateUnidadMedidaAsync(unidadMedida);
        }
        public Task DeleteUnidadMedidaAsync(int id)
        {
            return _unidadMedidaRepository.DeleteUnidadMedidaAsync(id);
        }
    }
}
