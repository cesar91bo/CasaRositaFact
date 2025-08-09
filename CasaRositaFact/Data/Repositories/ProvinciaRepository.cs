using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class ProvinciaRepository : IProvinciaRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public ProvinciaRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<Provincia>> GetAllProvinciasAsync()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Provincias
                           .AsNoTracking()
                           .ToListAsync();
        }

        public async Task<Provincia> GetProvinciaByIdAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();
            var provincia = await db.Provincias
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(p => p.IdProvincia == id);

            if (provincia is null)
                throw new InvalidOperationException($"No se encontró la provincia con Id '{id}'.");

            return provincia;
        }

        public async Task<Provincia> GetProvinciaByNombreAsync(string nombre)
        {
            await using var db = await _factory.CreateDbContextAsync();
            var provincia = await db.Provincias
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(p => p.Nombre == nombre);

            if (provincia is null)
                throw new InvalidOperationException($"No se encontró una provincia con el nombre '{nombre}'.");

            return provincia;
        }
    }
}
