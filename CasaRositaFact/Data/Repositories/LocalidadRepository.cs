using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class LocalidadRepository : ILocalidadRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public LocalidadRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<Localidad>> GetAllLocalidadesAsync()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Localidades
                           .AsNoTracking()
                           .Include(l => l.Provincia)
                           .ToListAsync();
        }

        public async Task<Localidad> GetLocalidadByIdAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();
            var localidad = await db.Localidades
                                    .AsNoTracking()
                                    .Include(l => l.Provincia)
                                    .FirstOrDefaultAsync(l => l.IdLocalidad == id);

            if (localidad is null)
                throw new Exception("Localidad no encontrada");

            return localidad;
        }

        public async Task<IEnumerable<Localidad>> GetLocalidadByProvinciaIdAsync(int provinciaId)
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Localidades
                           .AsNoTracking()
                           .Where(l => l.IdProvincia == provinciaId)
                           .ToListAsync();
        }
    }
}
