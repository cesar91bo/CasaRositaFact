using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;

namespace CasaRositaFact.Services
{
    public class RegimenService
    {
        public readonly IRegimenRepository _regimenRepository;
        public RegimenService(IRegimenRepository regimenRepository)
        {
            _regimenRepository = regimenRepository;
        }
        public Task<IEnumerable<RegimenImpositivo>> GetAllRegimenesAsync()
        {
            return _regimenRepository.GetAllRegimenesAsync();
        }
        public Task<RegimenImpositivo> GetRegimenByIdAsync(int id)
        {
            return _regimenRepository.GetRegimenByIdAsync(id);
        }
    }
}
