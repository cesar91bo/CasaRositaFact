using CasaRositaFact.Data.IRepositories;
using CasaRositaFact.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class UnidadMedidaRepository : IUnidadMedidaRepository
    {
        private readonly ApplicationDbContext _context;
        public UnidadMedidaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UnidadMedida>> GetAllUnidadMedidaAsync()
        {
            return await _context.UnidadesMedida.ToListAsync();
        }
        public async Task<UnidadMedida?> GetUnidadMedidaByIdAsync(int id)
        {
            return await _context.UnidadesMedida.FindAsync(id);
        }
        public async Task AddUnidadMedidaAsync(UnidadMedida unidadMedida)
        {
            _context.UnidadesMedida.Add(unidadMedida);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUnidadMedidaAsync(UnidadMedida unidadMedida)
        {
            _context.UnidadesMedida.Update(unidadMedida);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUnidadMedidaAsync(int id)
        {
            var unidadMedida = await GetUnidadMedidaByIdAsync(id);
            if (unidadMedida != null)
            {
                _context.UnidadesMedida.Remove(unidadMedida);
                await _context.SaveChangesAsync();
            }
        }
    }
}
