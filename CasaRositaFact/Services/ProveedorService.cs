using CasaRositaFact.Data.IRepositories;
using CasaRositaFact.Models;

namespace CasaRositaFact.Services
{
    public class ProveedorService
    {
        private readonly IProveedorRepository _proveedorRepository;
        public ProveedorService(IProveedorRepository proveedorRepository) 
        {
            _proveedorRepository = proveedorRepository;
        }
        public Task<IEnumerable<Proveedor?>> GetAllProveedoresAsync()
        {
            return _proveedorRepository.GetAllProveedoresAsync();
        }
        public async Task<Proveedor?> GetProveedorByIdAsync(int id)
        {
            return await _proveedorRepository.GetProveedorByIdAsync(id);
        }
        public async Task AddProveedorAsync(Proveedor proveedor)
        {
            await _proveedorRepository.AddProveedorAsync(proveedor);
        }
        public async Task UpdateProveedorAsync(Proveedor proveedor)
        {
            await _proveedorRepository.UpdateProveedorAsync(proveedor);
        }
        public async Task DeleteProveedorAsync(int id)
        {
            await _proveedorRepository.DeleteProveedorAsync(id);
        }
    }
}
