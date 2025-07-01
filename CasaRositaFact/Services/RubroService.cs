using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;

namespace CasaRositaFact.Services
{
    public class RubroService : IRubroRepository
    {
        private readonly IRubroRepository _rubroRepository;
        public RubroService(IRubroRepository rubroRepository)
        {
            _rubroRepository = rubroRepository;
        }
        public Task AddRubroAsync(Rubro rubro)
        {
            return _rubroRepository.AddRubroAsync(rubro);
        }
        public Task DeleteRubroAsync(int id)
        {
            return _rubroRepository.DeleteRubroAsync(id);
        }
        public Task<IEnumerable<Rubro>> GetAllRubrosAsync()
        {
            return _rubroRepository.GetAllRubrosAsync();
        }
        public Task<Rubro?> GetRubroByIdAsync(int id)
        {
            return _rubroRepository.GetRubroByIdAsync(id);
        }
        public Task UpdateRubroAsync(Rubro rubro)
        {
            return _rubroRepository.UpdateRubroAsync(rubro);
        }
    }
}
