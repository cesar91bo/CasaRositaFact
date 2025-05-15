using CasaRositaFact.Data.IRepositories;
using CasaRositaFact.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly ApplicationDbContext _context;
        public FacturaRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task AddFacturaAsync(Factura factura)
        {
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteFacturaAsync(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);
            if (factura != null)
            {
                _context.Facturas.Remove(factura);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Factura>> GetAllFacturasAsync()
        {
            return await _context.Facturas.ToListAsync();
        }
        public async Task<Factura> GetFacturaByIdAsync(int id)
        {
            var factura = await _context.Facturas.FirstOrDefaultAsync(f => f.IdFactura == id);
            if (factura == null)
                throw new Exception("Factura no encontrada");
            return factura;
        }
        public async Task<IEnumerable<Factura>> GetFacturasByClienteIdAsync(int clienteId)
        {
            return await _context.Facturas.Where(f => f.IdCliente == clienteId).ToListAsync();
        }
        public async Task<IEnumerable<Factura>> GetFacturasByFechaAsync(DateTime fecha)
        {
            return await _context.Facturas.Where(f => f.FechaEmision.Date == fecha.Date).ToListAsync();
        }
        public async Task<IEnumerable<Factura>> GetFacturasByRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _context.Facturas.Where(f => f.FechaEmision.Date >= fechaInicio.Date && f.FechaEmision.Date <= fechaFin.Date).ToListAsync();
        }
        public async Task UpdateFacturaAsync(Factura factura)
        {
            var existingFactura = await _context.Facturas.FindAsync(factura.IdFactura);
            if (existingFactura != null)
            {
                _context.Entry(existingFactura).CurrentValues.SetValues(factura);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> AnularFacturaAsync(int idFactura, int idUsuario)
        {
            var factura = await _context.Facturas.FindAsync(idFactura);
            if (factura != null)
            {
                factura.Anulada = true;
                factura.FechaAnulacion = DateTime.Now;
                factura.IdUsuarioAnulacion = idUsuario;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
