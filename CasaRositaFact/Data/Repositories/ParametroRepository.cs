using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class ParametroRepository : IParametroRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public ParametroRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task AddParametroAsync(Parametro parametro)
        {
            await using var db = await _factory.CreateDbContextAsync();
            db.Parametros.Add(parametro);
            await db.SaveChangesAsync();
        }

        public async Task DeleteParametroAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();

            // Ajustá el campo de PK si corresponde (IdParametro vs IdEmpresa)
            var parametro = await db.Parametros.FirstOrDefaultAsync(p => p.IdEmpresa == id);
            // Alternativa si tu PK es IdParametro: var parametro = await db.Parametros.FindAsync(id);

            if (parametro is null) return;

            db.Parametros.Remove(parametro);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Parametro>> GetAllParametrosAsync()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Parametros
                           .AsNoTracking()
                           .ToListAsync();
        }

        public async Task<Parametro?> GetParametroByIdAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();
            // Mantengo tu criterio de búsqueda por IdEmpresa
            return await db.Parametros
                           .AsNoTracking()
                           .FirstOrDefaultAsync(p => p.IdEmpresa == id);
            // Si tu PK real es IdParametro, cambiá el predicado o usá FindAsync(id).
        }

        public async Task UpdateParametroAsync(Parametro parametro)
        {
            await using var db = await _factory.CreateDbContextAsync();
            db.Parametros.Update(parametro);
            await db.SaveChangesAsync();
        }

        public async Task<decimal> GetPorcentajeGanancia()
        {
            await using var db = await _factory.CreateDbContextAsync();
            var parametro = await db.Parametros
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync();
            return parametro?.PorcentajeGanancia ?? 0m;
        }
    }
}
