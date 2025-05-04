using CasaRositaFact.Data.IRepositories;
using CasaRositaFact.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class LocalidadRepository : ILocalidadRepository
    {
        private readonly ApplicationDbContext _context;
        public LocalidadRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Localidad>> GetAllLocalidadesAsync()
        {
            return await _context.Localidades
                .Include(l => l.Provincia)
                .ToListAsync();
        }

        public Task<Localidad> GetLocalidadByIdAsync(int id)
        {
            return _context.Localidades.FirstAsync(l => l.IdLocalidad == id);
        }

        public async Task<IEnumerable<Localidad>> GetLocalidadByProvinciaIdAsync(int provinciaId)
        {
            return await _context.Localidades.Where(l => l.IdProvincia == provinciaId).ToListAsync();
        }
    }
}
