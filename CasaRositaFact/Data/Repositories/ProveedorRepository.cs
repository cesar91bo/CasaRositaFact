using CasaRositaFact.Data.IRepositories;
using CasaRositaFact.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly ApplicationDbContext _context;
        public ProveedorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task AddProveedorAsync(Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);
            return _context.SaveChangesAsync();
        }
        public Task DeleteProveedorAsync(int id)
        {
            var proveedor = _context.Proveedores.Find(id);
            if (proveedor != null)
            {
                _context.Proveedores.Remove(proveedor);
                return _context.SaveChangesAsync();
            }
            return Task.CompletedTask;
        }
        public async Task<IEnumerable<Proveedor?>> GetAllProveedoresAsync()
        {
            return await _context.Proveedores.ToListAsync();
        }
        public async Task<Proveedor?> GetProveedorByIdAsync(int id)
        {
            var proveedor = await _context.Proveedores
                .Include(p => p.Banco)
                .FirstOrDefaultAsync(p => p.IdProveedor == id);

            return proveedor;
        }
        public Task UpdateProveedorAsync(Proveedor proveedor)
        {
            _context.Proveedores.Update(proveedor);
            return _context.SaveChangesAsync();
        }
    }
}
