using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class FacturaDetalleRepository : IFacturaDetalleRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public FacturaDetalleRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task AddFacturaDetalleAsync(FacturaDetalle facturaDetalle)
        {
            await using var db = await _factory.CreateDbContextAsync();
            db.FacturaDetalles.Add(facturaDetalle);
            await db.SaveChangesAsync();
        }

        public async Task DeleteFacturaDetalleAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();

            // Si tu PK es IdFacturaDetalle:
            var facturaDetalle = await db.FacturaDetalles
                                         .FirstOrDefaultAsync(fd => fd.IdFacturaDetalle == id);
            // (Alternativa si FindAsync funciona con tu PK: var facturaDetalle = await db.FacturaDetalles.FindAsync(id);)

            if (facturaDetalle is null) return;

            db.FacturaDetalles.Remove(facturaDetalle);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<FacturaDetalle>> GetAllFacturaDetallesAsync()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.FacturaDetalles
                           .AsNoTracking()
                           .ToListAsync();
        }

        public async Task<FacturaDetalle> GetFacturaDetalleByIdAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();
            var facturaDetalle = await db.FacturaDetalles
                                         .AsNoTracking()
                                         .FirstOrDefaultAsync(fd => fd.IdFacturaDetalle == id);

            if (facturaDetalle is null)
                throw new Exception("Factura Detalle no encontrado");

            return facturaDetalle;
        }

        public async Task<IEnumerable<FacturaDetalle>> GetFacturaDetallesByFacturaIdAsync(int facturaId)
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.FacturaDetalles
                           .AsNoTracking()
                           .Where(fd => fd.IdFactura == facturaId)
                           .ToListAsync();
        }

        public async Task UpdateFacturaDetalleAsync(FacturaDetalle facturaDetalle)
        {
            await using var db = await _factory.CreateDbContextAsync();
            db.FacturaDetalles.Update(facturaDetalle);
            await db.SaveChangesAsync();
        }
    }
}
