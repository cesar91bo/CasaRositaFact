using CasaRositaFact.Data.Entities;

namespace CasaRositaFact.Data.IRepositories
{
    public interface IProvinciaRepository
    {
        Task<IEnumerable<Provincia>> GetAllProvinciasAsync();
        Task<Provincia> GetProvinciaByIdAsync(int id);
        Task<Provincia> GetProvinciaByNombreAsync(string nombre);
    }
}
