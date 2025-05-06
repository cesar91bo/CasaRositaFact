using CasaRositaFact.Data.IRepositories;
using CasaRositaFact.Models;

namespace CasaRositaFact.Services
{
    public class BancoService
    {
        private readonly IBancoRepository bancoRepository;

        public BancoService(IBancoRepository bancoRepository)
        {
            this.bancoRepository = bancoRepository;
        }

        public Task<IEnumerable<Banco>> GetAllBancosAsync()
        {
            return bancoRepository.GetAllBancosAsync();
        }
        public Task<Banco?> GetBancoByIdAsync(int id)
        {
            return bancoRepository.GetBancoByIdAsync(id);
        }
        public Task AddBancoAsync(Banco banco)
        {
            return bancoRepository.AddBancoAsync(banco);
        }
        public Task UpdateBancoAsync(Banco banco)
        {
            return bancoRepository.UpdateBancoAsync(banco);
        }
        public Task DeleteBancoAsync(int id)
        {
            return bancoRepository.DeleteBancoAsync(id);
        }
    }
}
