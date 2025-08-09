using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class UnidadMedidaRepository : IUnidadMedidaRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public UnidadMedidaRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<UnidadMedida>> GetAllUnidadMedidaAsync()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.UnidadesMedida
                           .AsNoTracking()
                           .ToListAsync();
        }

        public async Task<UnidadMedida?> GetUnidadMedidaByIdAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();
            // Si tu PK es IdUnidadMedida:
            return await db.UnidadesMedida
                           .AsNoTracking()
                           .FirstOrDefaultAsync(u => u.IdUnidadMedida == id);
            // Alternativa si FindAsync aplica a tu PK: return await db.UnidadesMedida.FindAsync(id);
        }

        public async Task AddUnidadMedidaAsync(UnidadMedida unidadMedida)
        {
            await using var db = await _factory.CreateDbContextAsync();
            db.UnidadesMedida.Add(unidadMedida);
            await db.SaveChangesAsync();
        }

        public async Task UpdateUnidadMedidaAsync(UnidadMedida unidadMedida)
        {
            await using var db = await _factory.CreateDbContextAsync();
            db.UnidadesMedida.Update(unidadMedida);
            await db.SaveChangesAsync();
        }

        public async Task DeleteUnidadMedidaAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();

            var unidadMedida = await db.UnidadesMedida
                                       .FirstOrDefaultAsync(u => u.IdUnidadMedida == id);
            if (unidadMedida is null) return;

            db.UnidadesMedida.Remove(unidadMedida);
            await db.SaveChangesAsync();
        }
    }
}
