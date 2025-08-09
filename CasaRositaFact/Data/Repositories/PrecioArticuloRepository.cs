using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class PrecioArticuloRepository : IPrecioArticuloRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public PrecioArticuloRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task AddPrecioAsync(PrecioArticulo precioArticulo)
        {
            await using var db = await _factory.CreateDbContextAsync();
            db.PreciosArticulos.Add(precioArticulo);
            await db.SaveChangesAsync();
        }

        public async Task DeletePrecioAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();

            // Si tu PK es IdPrecioArticulo, podrías usar FindAsync(id)
            var precioArticulo = await db.PreciosArticulos
                                         .FirstOrDefaultAsync(p => p.IdPrecioArticulo == id);

            if (precioArticulo is null)
                throw new Exception("Precio no encontrado");

            db.PreciosArticulos.Remove(precioArticulo);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<PrecioArticulo?>> GetAllPreciosAsync()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.PreciosArticulos
                           .AsNoTracking()
                           .Include(p => p.Articulo)
                           .Include(p => p.TipoIva)
                           .ToListAsync();
        }

        public async Task<List<PrecioArticulo>> GetPrecioByArticuloIdAsync(int idArticulo)
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.PreciosArticulos
                           .AsNoTracking()
                           .Where(p => p.IdArticulo == idArticulo)
                           .ToListAsync();
        }

        public async Task UpdatePrecioAsync(PrecioArticulo precioArticulo)
        {
            await using var db = await _factory.CreateDbContextAsync();
            db.PreciosArticulos.Update(precioArticulo);
            await db.SaveChangesAsync();
        }

        public async Task<PrecioArticulo?> GetLastPrecioByArticuloIdAsync(int idArticulo)
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.PreciosArticulos
                           .AsNoTracking()
                           .Where(p => p.IdArticulo == idArticulo)
                           .OrderByDescending(p => p.FechaIncio) // ajustá el nombre si es FechaInicio
                           .FirstOrDefaultAsync();
        }
    }
}
