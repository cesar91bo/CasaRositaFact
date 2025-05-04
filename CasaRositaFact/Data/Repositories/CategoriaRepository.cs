using CasaRositaFact.Data;
using CasaRositaFact.Data.IRepositories;
using CasaRositaFact.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task AddCategoriaAsync(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            return _context.SaveChangesAsync();
        }

        public Task DeleteCategoriaAsync(int id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                return _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Categoria no encontrada");
            }
        }

        public async Task<IEnumerable<Categoria?>> GetAllCategoriasAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria?> GetCategoriaByIdAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public  Task UpdateCategoriaAsync(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            return _context.SaveChangesAsync();
        }
    }
}
