using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class RegimenRepository : IRegimenRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public RegimenRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<RegimenImpositivo>> GetAllRegimenesAsync()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.RegimenesImpositivos
                           .AsNoTracking()
                           .ToListAsync();
        }

        public async Task<RegimenImpositivo> GetRegimenByIdAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();
            var regimen = await db.RegimenesImpositivos
                                  .AsNoTracking()
                                  .FirstOrDefaultAsync(r => r.IdRegimenImpositivo == id);

            if (regimen is null)
                throw new InvalidOperationException($"No se encontró el régimen impositivo con Id '{id}'.");

            return regimen;
        }
    }
}
