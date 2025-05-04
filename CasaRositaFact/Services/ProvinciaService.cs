using CasaRositaFact.Data.IRepositories;
using CasaRositaFact.Models;

namespace CasaRositaFact.Services
{
    public class ProvinciaService
    {
        private readonly IProvinciaRepository provinciaRepository;

        public ProvinciaService(IProvinciaRepository provinciaRepository)
        {
            this.provinciaRepository = provinciaRepository;
        }

        public Task<IEnumerable<Provincia>> GetAllProvinciasAsync()
        {
            return provinciaRepository.GetAllProvinciasAsync();
        }
        public Task<Provincia> GetProvinciaByIdAsync(int id)
        {
            return provinciaRepository.GetProvinciaByIdAsync(id);
        }
        public Task<Provincia> GetProvinciaByNombreAsync(string nombre)
        {
            return provinciaRepository.GetProvinciaByNombreAsync(nombre);
        }
    }
}
