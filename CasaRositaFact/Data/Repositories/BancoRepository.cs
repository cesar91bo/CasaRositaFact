using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class BancoRepository : IBancoRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public BancoRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task AddBancoAsync(Banco banco)
        {
            await using var db = await _factory.CreateDbContextAsync();
            db.Bancos.Add(banco);
            await db.SaveChangesAsync();
        }

        public async Task DeleteBancoAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();

            // Si la PK es IdBanco:
            var banco = await db.Bancos.FirstOrDefaultAsync(b => b.IdBanco == id);
            // (Alternativa si FindAsync funciona con tu PK: var banco = await db.Bancos.FindAsync(id);)

            if (banco is null) return;

            db.Bancos.Remove(banco);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Banco>> GetAllBancosAsync()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Bancos
                           .AsNoTracking()
                           .Include(b => b.Proveedores)
                           .ToListAsync();
        }

        public async Task<Banco?> GetBancoByIdAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Bancos
                           .AsNoTracking()
                           .Include(b => b.Proveedores)
                           .FirstOrDefaultAsync(b => b.IdBanco == id);
        }

        public async Task UpdateBancoAsync(Banco banco)
        {
            await using var db = await _factory.CreateDbContextAsync();
            db.Bancos.Update(banco);
            await db.SaveChangesAsync();
        }
    }
}
