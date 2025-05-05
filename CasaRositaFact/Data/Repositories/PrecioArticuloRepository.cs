using CasaRositaFact.Data.IRepositories;
using CasaRositaFact.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class PrecioArticuloRepository : IPrecioArticuloRepository
    {
        private readonly ApplicationDbContext _context;
        public PrecioArticuloRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddPrecioAsync(PrecioArticulo precioArticulo)
        {
            _context.PreciosArticulos.Add(precioArticulo);
            await _context.SaveChangesAsync();
        }
        public Task DeletePrecioAsync(int id)
        {
            var precioArticulo = _context.PreciosArticulos.Find(id);
            if (precioArticulo != null)
            {
                _context.PreciosArticulos.Remove(precioArticulo);
                return _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Precio no encontrado");
            }
        }
        public async Task<IEnumerable<PrecioArticulo?>> GetAllPreciosAsync()
        {
            return await _context.PreciosArticulos
                .Include(p => p.Articulo)
                .Include(p => p.TipoIva)
                .ToListAsync();
        }
        public Task<List<PrecioArticulo>> GetPrecioByArticuloIdAsync(int idArticulo)
        {
            return _context.PreciosArticulos
                .Where(p => p.IdArticulo == idArticulo)
                .ToListAsync();
        }
        public Task UpdatePrecioAsync(PrecioArticulo precioArticulo)
        {
            _context.PreciosArticulos.Update(precioArticulo);
            return _context.SaveChangesAsync();
        }
        public async Task<PrecioArticulo?> GetLastPrecioByArticuloIdAsync(int idArticulo)
        {
            return await _context.PreciosArticulos
                .Where(p => p.IdArticulo == idArticulo)
                .OrderByDescending(p => p.FechaIncio)
                .FirstOrDefaultAsync();
        }
        }
}
