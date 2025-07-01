using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class RegimenRepository : IRegimenRepository
    {
        private readonly ApplicationDbContext _context;
        public RegimenRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<RegimenImpositivo>> GetAllRegimenesAsync()
        {
            return await _context.RegimenesImpositivos.ToListAsync();
        }
        public Task<RegimenImpositivo> GetRegimenByIdAsync(int id)
        {
            return _context.RegimenesImpositivos.FirstAsync(r => r.IdRegimenImpositivo == id);
        }
    }
}
