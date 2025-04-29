using CasaRositaFact.Models;

namespace CasaRositaFact.Data.Repositories
{
    public interface ILocalidadRepository
    {
        Task<IEnumerable<Localidad>> GetAllLocalidadesAsync();
        Task<Localidad> GetLocalidadByIdAsync(int id);
        Task<IEnumerable<Localidad>> GetLocalidadByProvinciaIdAsync(int provinciaId);
    }
}
