using CasaRositaFact.Data.Repositories;
using CasaRositaFact.Models;

namespace CasaRositaFact.Services
{
    public class PrecioArticuloService
    {
        public readonly IPrecioArticuloRepository _precioArticuloRepository;

        public PrecioArticuloService(IPrecioArticuloRepository precioArticuloRepository)
        {
            _precioArticuloRepository = precioArticuloRepository;
        }
        public Task<IEnumerable<PrecioArticulo>> GetAllPreciosAsync()
        {
            return _precioArticuloRepository.GetAllPreciosAsync();
        }
        public Task<List<PrecioArticulo>> GetPrecioByIdAsync(int idArticulo)
        {
            return _precioArticuloRepository.GetPrecioByArticuloIdAsync(idArticulo);
        }
        public Task AddPrecioAsync(PrecioArticulo precioArticulo)
        {
            return _precioArticuloRepository.AddPrecioAsync(precioArticulo);
        }
        public Task UpdatePrecioAsync(PrecioArticulo precioArticulo)
        {
            return _precioArticuloRepository.UpdatePrecioAsync(precioArticulo);
        }
        public Task DeletePrecioAsync(int id)
        {
            return _precioArticuloRepository.DeletePrecioAsync(id);
        }
        public Task<List<PrecioArticulo>> GetPrecioByArticuloIdAsync(int id)
        {
            return _precioArticuloRepository.GetPrecioByArticuloIdAsync(id);
        }
        public Task<PrecioArticulo?> GetLastPrecioByArticuloIdAsync(int idArticulo)
        {
            return _precioArticuloRepository.GetLastPrecioByArticuloIdAsync(idArticulo);
        }
    }
}
