using CasaRositaFact.Models;

namespace CasaRositaFact.Data.IRepositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllClienteAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        Task AddClienteAsync(Cliente cliente);
        Task UpdateClienteAsync(Cliente cliente);
        Task DeleteClienteAsync(int id);
    }
}
