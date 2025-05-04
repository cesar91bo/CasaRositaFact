using CasaRositaFact.Models;

namespace CasaRositaFact.Data.IRepositories
{
    public interface IArticuloRepository
    {
        Task<IEnumerable<Articulo>> GetAllAsync();
        Task<Articulo> GetByIdAsync(int id);
        Task AddAsync(Articulo articulo);
        Task UpdateAsync(Articulo articulo);
        Task DeleteAsync(int id);
        Task<IEnumerable<Articulo>> GetByCategoriaIdAsync(int categoriaId);
        Task<IEnumerable<Articulo>> GetByRubroIdAsync(int rubroId);
        Task<IEnumerable<Articulo>> GetByProveedorIdAsync(int proveedorId);
        Task<IEnumerable<Articulo>> GetByUnidadMedidaIdAsync(int unidadMedidaId);
        Task<IEnumerable<Articulo>> GetByNombreAsync(string nombre);
    }
}
