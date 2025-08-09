using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public CategoriaRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task AddCategoriaAsync(Categoria categoria)
        {
            await using var db = await _factory.CreateDbContextAsync();
            db.Categorias.Add(categoria);
            await db.SaveChangesAsync();
        }

        public async Task DeleteCategoriaAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();

            // Si tu PK es IdCategoria:
            var categoria = await db.Categorias.FirstOrDefaultAsync(c => c.IdCategoria == id);
            // (Si tu PK está configurada para FindAsync, podrías usar: var categoria = await db.Categorias.FindAsync(id);)

            if (categoria is null)
                throw new Exception("Categoria no encontrada");

            db.Categorias.Remove(categoria);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Categoria?>> GetAllCategoriasAsync()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Categorias
                           .AsNoTracking()
                           .ToListAsync();
        }

        public async Task<Categoria?> GetCategoriaByIdAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();
            // Usamos AsNoTracking para lectura
            return await db.Categorias
                           .AsNoTracking()
                           .FirstOrDefaultAsync(c => c.IdCategoria == id);
            // (Alternativa: return await db.Categorias.FindAsync(id);)
        }

        public async Task UpdateCategoriaAsync(Categoria categoria)
        {
            await using var db = await _factory.CreateDbContextAsync();
            db.Categorias.Update(categoria);
            await db.SaveChangesAsync();
        }
    }
}
