using CasaRositaFact.Data.Repositories;
using CasaRositaFact.Models;

namespace CasaRositaFact.Services
{
    public class LocalidadService
    {
        private readonly ILocalidadRepository localidadRepository;

        public LocalidadService(ILocalidadRepository localidadRepository)
        {
            this.localidadRepository = localidadRepository;
        }
        public Task<IEnumerable<Localidad>> GetAllLocalidadesAsync()
        {
            return localidadRepository.GetAllLocalidadesAsync();
        }
        public Task<Localidad> GetLocalidadByIdAsync(int id)
        {
            return localidadRepository.GetLocalidadByIdAsync(id);
        }
        public Task<IEnumerable<Localidad>> GetLocalidadByProvinciaIdAsync(int provinciaId)
        {
            return localidadRepository.GetLocalidadByProvinciaIdAsync(provinciaId);
        }
    }
}
