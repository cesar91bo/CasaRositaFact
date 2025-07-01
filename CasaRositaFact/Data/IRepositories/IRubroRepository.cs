using CasaRositaFact.Data.Entities;

namespace CasaRositaFact.Data.IRepositories
{
    public interface IRubroRepository
    {
        Task<IEnumerable<Rubro>> GetAllRubrosAsync();
        Task<Rubro?> GetRubroByIdAsync(int id);
        Task AddRubroAsync(Rubro rubro);
        Task UpdateRubroAsync(Rubro rubro);
        Task DeleteRubroAsync(int id);
    }
}
