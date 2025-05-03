using CasaRositaFact.Models;

namespace CasaRositaFact.Data.Repositories
{
    public interface IPrecioArticuloRepository
    {
        Task<IEnumerable<PrecioArticulo?>> GetAllPreciosAsync();
        Task <List<PrecioArticulo>> GetPrecioByArticuloIdAsync(int idArticulo);
        Task AddPrecioAsync(PrecioArticulo precioArticulo);
        Task UpdatePrecioAsync(PrecioArticulo precioArticulo);
        Task DeletePrecioAsync(int id);
        Task<PrecioArticulo?> GetLastPrecioByArticuloIdAsync(int idArticulo);
    }
}
