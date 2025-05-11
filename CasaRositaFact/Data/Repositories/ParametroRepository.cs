using CasaRositaFact.Data.IRepositories;
using CasaRositaFact.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class ParametroRepository : IParametroRepository
    {
        private readonly ApplicationDbContext _context;
        public ParametroRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task AddParametroAsync(Parametro parametro)
        {
            _context.Parametros.Add(parametro);
            return _context.SaveChangesAsync();
        }
        public Task DeleteParametroAsync(int id)
        {
            var parametro = _context.Parametros.Find(id);
            if (parametro != null)
            {
                _context.Parametros.Remove(parametro);
                return _context.SaveChangesAsync();
            }
            return Task.CompletedTask; // Or handle the case where the parameter is not found
        }
        public async Task<IEnumerable<Parametro>> GetAllParametrosAsync()
        {
            return await _context.Parametros.ToListAsync();
        }
        public async Task<Parametro?> GetParametroByIdAsync(int id)
        {
            return await _context.Parametros.FirstOrDefaultAsync(p => p.IdEmpresa == id);
        }

        public Task UpdateParametroAsync(Parametro parametro)
        {
            _context.Parametros.Update(parametro);
            return _context.SaveChangesAsync();
        }
        public async Task<decimal> GetPorcentajeGanancia()
        {
            var parametro = await _context.Parametros.FirstOrDefaultAsync();
            return parametro?.PorcentajeGanancia ?? 0;
        }

    }
}
