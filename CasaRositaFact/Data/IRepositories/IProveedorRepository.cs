using CasaRositaFact.Models;

namespace CasaRositaFact.Data.IRepositories
{
    public interface IProveedorRepository
    {
        Task<IEnumerable<Proveedor?>> GetAllProveedoresAsync();
        Task<Proveedor?> GetProveedorByIdAsync(int id);
        Task AddProveedorAsync(Proveedor proveedor);
        Task UpdateProveedorAsync(Proveedor proveedor);
        Task DeleteProveedorAsync(int id);
    }
}
