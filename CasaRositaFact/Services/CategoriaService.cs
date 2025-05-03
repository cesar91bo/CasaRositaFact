using CasaRositaFact.Data.Repositories;
using CasaRositaFact.Models;

namespace CasaRositaFact.Services
{
    public class CategoriaService
    {
        public readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(ICategoriaRepository categoriaRepository) { _categoriaRepository = categoriaRepository; }
        public Task<IEnumerable<Categoria?>> GetAllCategoriasAsync()
        {
            return _categoriaRepository.GetAllCategoriasAsync();
        }
        public Task<Categoria?> GetCategoriaByIdAsync(int id)
        {
            return _categoriaRepository.GetCategoriaByIdAsync(id);
        }
        public Task AddCategoriaAsync(Categoria categoria)
        {
            return _categoriaRepository.AddCategoriaAsync(categoria);
        }
        public Task UpdateCategoriaAsync(Categoria categoria)
        {
            return _categoriaRepository.UpdateCategoriaAsync(categoria);
        }
        public Task DeleteCategoriaAsync(int id)
        {
            return _categoriaRepository.DeleteCategoriaAsync(id);
        }
    }
}
