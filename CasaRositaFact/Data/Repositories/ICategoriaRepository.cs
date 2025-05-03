using CasaRositaFact.Models;

namespace CasaRositaFact.Data.Repositories
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria?>> GetAllCategoriasAsync();
        Task<Categoria?> GetCategoriaByIdAsync(int id);
        Task AddCategoriaAsync(Categoria categoria);
        Task UpdateCategoriaAsync(Categoria categoria);
        Task DeleteCategoriaAsync(int id);
    }
}
