using CasaRositaFact.Data.Entities;

namespace CasaRositaFact.Data.IRepositories
{
    public interface IBancoRepository
    {
        Task<IEnumerable<Banco>> GetAllBancosAsync();
        Task<Banco?> GetBancoByIdAsync(int id);
        Task AddBancoAsync(Banco banco);
        Task UpdateBancoAsync(Banco banco);
        Task DeleteBancoAsync(int id);
    }
}
