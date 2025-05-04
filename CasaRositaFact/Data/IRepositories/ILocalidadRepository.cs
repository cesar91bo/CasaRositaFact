using CasaRositaFact.Models;

namespace CasaRositaFact.Data.IRepositories
{
    public interface ILocalidadRepository
    {
        Task<IEnumerable<Localidad>> GetAllLocalidadesAsync();
        Task<Localidad> GetLocalidadByIdAsync(int id);
        Task<IEnumerable<Localidad>> GetLocalidadByProvinciaIdAsync(int provinciaId);
    }
}
