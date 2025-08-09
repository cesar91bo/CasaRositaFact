using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public ProveedorRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task AddProveedorAsync(Proveedor proveedor)
        {
            await using var db = await _factory.CreateDbContextAsync();
            db.Proveedores.Add(proveedor);
            await db.SaveChangesAsync();
        }

        public async Task DeleteProveedorAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();

            // Si tu PK es IdProveedor:
            var proveedor = await db.Proveedores.FirstOrDefaultAsync(p => p.IdProveedor == id);
            // (Si FindAsync funciona con tu PK: var proveedor = await db.Proveedores.FindAsync(id);)

            if (proveedor is null) return;

            db.Proveedores.Remove(proveedor);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Proveedor>> GetAllProveedoresAsync()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Proveedores
                           .AsNoTracking()
                           .ToListAsync();
        }

        public async Task<Proveedor> GetProveedorByIdAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();
            var proveedor = await db.Proveedores
                                    .AsNoTracking()
                                    .Include(p => p.Banco)
                                    .FirstOrDefaultAsync(p => p.IdProveedor == id);

            // Mantengo la firma no-nullable; si no existe, lanzo excepción.
            if (proveedor is null)
                throw new Exception("Proveedor no encontrado");

            return proveedor;
        }

        public async Task UpdateProveedorAsync(Proveedor proveedor)
        {
            await using var db = await _factory.CreateDbContextAsync();
            db.Proveedores.Update(proveedor);
            await db.SaveChangesAsync();
        }
    }
}
