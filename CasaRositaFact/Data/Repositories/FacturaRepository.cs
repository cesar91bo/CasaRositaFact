using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public FacturaRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task AddFacturaAsync(Factura factura)
        {
            await using var db = await _factory.CreateDbContextAsync();
            db.Facturas.Add(factura);
            await db.SaveChangesAsync();
        }

        public async Task DeleteFacturaAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();
            var factura = await db.Facturas.FirstOrDefaultAsync(f => f.IdFactura == id);
            if (factura is null) return;
            db.Facturas.Remove(factura);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Factura>> GetAllFacturasAsync()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Facturas
                           .AsNoTracking()
                           .ToListAsync();
        }

        public async Task<Factura> GetFacturaByIdAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();
            var factura = await db.Facturas
                                  .AsNoTracking()
                                  .FirstOrDefaultAsync(f => f.IdFactura == id);

            if (factura is null)
                throw new Exception("Factura no encontrada");

            return factura;
        }

        public async Task<IEnumerable<Factura>> GetFacturasByClienteIdAsync(int clienteId)
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Facturas
                           .AsNoTracking()
                           .Where(f => f.IdCliente == clienteId)
                           .ToListAsync();
        }

        public async Task<IEnumerable<Factura>> GetFacturasByFechaAsync(DateTime fecha)
        {
            await using var db = await _factory.CreateDbContextAsync();
            var desde = fecha.Date;
            var hastaExcl = desde.AddDays(1); // mejor que usar .Date en la columna (evita evaluaciones en memoria)
            return await db.Facturas
                           .AsNoTracking()
                           .Where(f => f.FechaEmision >= desde && f.FechaEmision < hastaExcl)
                           .ToListAsync();
        }

        public async Task<IEnumerable<Factura>> GetFacturasByRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            await using var db = await _factory.CreateDbContextAsync();
            var desde = fechaInicio.Date;
            var hastaExcl = fechaFin.Date.AddDays(1);
            return await db.Facturas
                           .AsNoTracking()
                           .Where(f => f.FechaEmision >= desde && f.FechaEmision < hastaExcl)
                           .ToListAsync();
        }

        public async Task UpdateFacturaAsync(Factura factura)
        {
            await using var db = await _factory.CreateDbContextAsync();
            db.Facturas.Update(factura);
            await db.SaveChangesAsync();
        }

        public async Task<bool> AnularFacturaAsync(int idFactura, int idUsuario)
        {
            await using var db = await _factory.CreateDbContextAsync();
            var factura = await db.Facturas.FirstOrDefaultAsync(f => f.IdFactura == idFactura);
            if (factura is null) return false;

            factura.Anulada = true;
            factura.FechaAnulacion = DateTime.Now;
            factura.IdUsuarioAnulacion = idUsuario;

            await db.SaveChangesAsync();
            return true;
        }
    }
}
