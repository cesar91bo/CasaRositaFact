using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public EmpresaRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task AddAsync(Empresa empresa)
        {
            await using var db = await _factory.CreateDbContextAsync();
            db.Empresas.Add(empresa);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();

            // Si tu PK es IdEmpresa:
            var empresa = await db.Empresas.FirstOrDefaultAsync(e => e.IdEmpresa == id);
            // (Si FindAsync funciona con tu PK: var empresa = await db.Empresas.FindAsync(id);)

            if (empresa is null) return;

            db.Empresas.Remove(empresa);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Empresa>> GetAllAsync()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Empresas
                           .AsNoTracking()
                           .ToListAsync();
        }

        public async Task<Empresa> GetByIdAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();
            var empresa = await db.Empresas
                                  .AsNoTracking()
                                  .FirstOrDefaultAsync(e => e.IdEmpresa == id);

            if (empresa is null)
                throw new Exception("Empresa no encontrada");

            return empresa;
        }

        public async Task UpdateAsync(Empresa empresa)
        {
            await using var db = await _factory.CreateDbContextAsync();
            db.Empresas.Update(empresa);
            await db.SaveChangesAsync();
        }
    }
}
