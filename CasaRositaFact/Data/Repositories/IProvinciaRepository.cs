using CasaRositaFact.Models;

namespace CasaRositaFact.Data.Repositories
{
    public interface IProvinciaRepository
    {
        Task<IEnumerable<Provincia>> GetAllProvinciasAsync();
        Task<Provincia> GetProvinciaByIdAsync(int id);
        Task<Provincia> GetProvinciaByNombreAsync(string nombre);
    }
}
