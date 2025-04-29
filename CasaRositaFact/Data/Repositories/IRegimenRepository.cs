using CasaRositaFact.Models;
namespace CasaRositaFact.Data.Repositories
{
    public interface IRegimenRepository
    {
        Task<IEnumerable<RegimenImpositivo>> GetAllRegimenesAsync();
        Task<RegimenImpositivo> GetRegimenByIdAsync(int id);
    }
}
