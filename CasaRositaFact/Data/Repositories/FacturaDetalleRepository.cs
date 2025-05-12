using CasaRositaFact.Data.IRepositories;
using CasaRositaFact.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class FacturaDetalleRepository : IFacturaDetalleRepository
    {
        private readonly ApplicationDbContext _context;
        public FacturaDetalleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddFacturaDetalleAsync(FacturaDetalle facturaDetalle)
        {
            _context.FacturaDetalles.Add(facturaDetalle);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteFacturaDetalleAsync(int id)
        {
            var facturaDetalle = await _context.FacturaDetalles.FindAsync(id);
            if (facturaDetalle != null)
            {
                _context.FacturaDetalles.Remove(facturaDetalle);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<FacturaDetalle>> GetAllFacturaDetallesAsync()
        {
            return await _context.FacturaDetalles.ToListAsync();
        }
        public async Task<FacturaDetalle> GetFacturaDetalleByIdAsync(int id)
        {
            var facturaDetalle = await _context.FacturaDetalles.FirstOrDefaultAsync(fd => fd.IdFacturaDetalle == id);
            if (facturaDetalle == null)
                throw new Exception("Factura Detalle no encontrado");
            return facturaDetalle;
        }
        public async Task<IEnumerable<FacturaDetalle>> GetFacturaDetallesByFacturaIdAsync(int facturaId)
        {
            return await _context.FacturaDetalles.Where(fd => fd.IdFactura == facturaId).ToListAsync();
        }
        public async Task UpdateFacturaDetalleAsync(FacturaDetalle facturaDetalle)
        {
            var existingFacturaDetalle = await _context.FacturaDetalles.FindAsync(facturaDetalle.IdFacturaDetalle);
            if (existingFacturaDetalle != null)
            {
                _context.Entry(existingFacturaDetalle).CurrentValues.SetValues(facturaDetalle);
                await _context.SaveChangesAsync();
            }
        }
    }
}
