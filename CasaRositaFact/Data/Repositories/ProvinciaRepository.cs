using CasaRositaFact.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class ProvinciaRepository : IProvinciaRepository
    {
        private readonly ApplicationDbContext _context;
        public ProvinciaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Provincia>> GetAllProvinciasAsync()
        {
            return await _context.Provincias.ToListAsync();
        }
        public async Task<Provincia> GetProvinciaByIdAsync(int id)
        {
            return await _context.Provincias.FirstAsync(p => p.IdProvincia == id);
        }
        public async Task<Provincia> GetProvinciaByNombreAsync(string nombre)
        {
            var provincia = await _context.Provincias.FirstOrDefaultAsync(p => p.Nombre == nombre);
            if (provincia == null)
            {
                throw new InvalidOperationException($"No se encontró una provincia con el nombre '{nombre}'.");
            }
            return provincia;
        }
    }
}
