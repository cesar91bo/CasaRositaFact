using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class RubroRepository : IRubroRepository
    {
        private readonly ApplicationDbContext _context;
        public RubroRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task AddRubroAsync(Rubro rubro)
        {
            _context.Rubros.Add(rubro);
            return _context.SaveChangesAsync();
        }

        public Task DeleteRubroAsync(int id)
        {
            var rubro = _context.Rubros.Find(id);
            if (rubro != null)
            {
                _context.Rubros.Remove(rubro);
                return _context.SaveChangesAsync();
            }
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Rubro>> GetAllRubrosAsync()
        {
            return await _context.Rubros.ToListAsync();
        }

        public Task<Rubro?> GetRubroByIdAsync(int id)
        {
            return _context.Rubros.FindAsync(id).AsTask();
        }

        public Task UpdateRubroAsync(Rubro rubro)
        {
            _context.Rubros.Update(rubro);
            return _context.SaveChangesAsync();
        }
    }
}
