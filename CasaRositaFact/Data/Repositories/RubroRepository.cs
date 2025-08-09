using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class RubroRepository : IRubroRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public RubroRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task AddRubroAsync(Rubro rubro)
        {
            await using var db = await _factory.CreateDbContextAsync();
            db.Rubros.Add(rubro);
            await db.SaveChangesAsync();
        }

        public async Task DeleteRubroAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();

            // Si tu PK es IdRubro, podés usar FindAsync(id)
            var rubro = await db.Rubros.FirstOrDefaultAsync(r => r.IdRubro == id);
            if (rubro is null) return;

            db.Rubros.Remove(rubro);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Rubro>> GetAllRubrosAsync()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Rubros
                           .AsNoTracking()
                           .ToListAsync();
        }

        public async Task<Rubro?> GetRubroByIdAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Rubros
                           .AsNoTracking()
                           .FirstOrDefaultAsync(r => r.IdRubro == id);
            // Alternativa si la PK coincide: return await db.Rubros.FindAsync(id);
        }

        public async Task UpdateRubroAsync(Rubro rubro)
        {
            await using var db = await _factory.CreateDbContextAsync();
            db.Rubros.Update(rubro);
            await db.SaveChangesAsync();
        }
    }
}
