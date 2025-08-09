using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class AuxiliarRepository : IAuxiliarRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public AuxiliarRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<TipoDocumento>> GetAllTipoDocumentoAsync()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.TiposDocumentos
                           .AsNoTracking()
                           .ToListAsync();
        }

        public async Task<TipoDocumento> GetTipoDocumentoByIdAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();
            // Mantengo tu comportamiento de devolver uno nuevo si no existe
            return await db.TiposDocumentos
                           .AsNoTracking()
                           .FirstOrDefaultAsync(x => x.IdTipoDocumento == id)
                   ?? new TipoDocumento();
        }

        public async Task<IEnumerable<LetraFactura>> GetAllLetraFacturaAsync()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.LetrasFacturas
                           .AsNoTracking()
                           .ToListAsync();
        }

        public async Task<LetraFactura> GetLetraFacturaByIdAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();
            var letraFactura = await db.LetrasFacturas
                                       .AsNoTracking()
                                       .Include(lf => lf.Facturas)
                                       .FirstOrDefaultAsync(lf => lf.IdLetraFactura == id);

            if (letraFactura is null)
                throw new Exception("Letra de factura no encontrada");

            return letraFactura;
        }

        public async Task<IEnumerable<ConceptoFactura>> GetAllConceptoFacturaAsync()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.ConceptosFacturas
                           .AsNoTracking()
                           .ToListAsync();
        }

        public async Task<ConceptoFactura> GetConceptoFacturaByIdAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();
            var conceptoFactura = await db.ConceptosFacturas
                                          .AsNoTracking()
                                          .Include(cf => cf.Facturas)
                                          .FirstOrDefaultAsync(cf => cf.IdConceptoFactura == id);

            if (conceptoFactura is null)
                throw new Exception("Concepto de factura no encontrado");

            return conceptoFactura;
        }

        public async Task<IEnumerable<FormaPago>> GetAllFormaPagoAsync()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.FormasPago
                           .AsNoTracking()
                           .ToListAsync();
        }

        public async Task<FormaPago> GetFormaPagoByIdAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();
            var formaPago = await db.FormasPago
                                    .AsNoTracking()
                                    .Include(fp => fp.Facturas)
                                    .FirstOrDefaultAsync(fp => fp.IdFormaPago == id);

            if (formaPago is null)
                throw new Exception("Forma de pago no encontrada");

            return formaPago;
        }

        public async Task<IEnumerable<TipoDocumentoFiscal>> GetAllTipoDocumentoFiscalAsync()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.TiposDocumentosFiscales
                           .AsNoTracking()
                           .ToListAsync();
        }

        public async Task<TipoDocumentoFiscal> GetTipoDocumentoFiscalByIdAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();
            var tipoDocumentoFiscal = await db.TiposDocumentosFiscales
                                              .AsNoTracking()
                                              .Include(tdf => tdf.Facturas)
                                              .FirstOrDefaultAsync(tdf => tdf.IdTipoDocumentoFiscal == id);

            if (tipoDocumentoFiscal is null)
                throw new Exception("Tipo de documento fiscal no encontrado");

            return tipoDocumentoFiscal;
        }

        public async Task<TipoIva> GetTipoIvaByIdAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.TiposIva
                           .AsNoTracking()
                           .FirstOrDefaultAsync(ti => ti.IdTipoIva == id)
                   ?? throw new Exception("Tipo de IVA no encontrado");
        }

        public async Task<IEnumerable<TipoIva>> GetAllTipoIvaAsync()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.TiposIva
                           .AsNoTracking()
                           .ToListAsync();
        }
    }
}
