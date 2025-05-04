using CasaRositaFact.Models;
namespace CasaRositaFact.Data.IRepositories
{
    public interface IRegimenRepository
    {
        Task<IEnumerable<RegimenImpositivo>> GetAllRegimenesAsync();
        Task<RegimenImpositivo> GetRegimenByIdAsync(int id);
    }
}
