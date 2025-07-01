using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class AuxiliarRepository : IAuxiliarRepository
    {
        private readonly ApplicationDbContext _context;
        public AuxiliarRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TipoDocumento>> GetAllTipoDocumentoAsync()
        {
            return await _context.TiposDocumentos.ToListAsync();
        }
        public async Task<TipoDocumento> GetTipoDocumentoByIdAsync(int id)
        {
            return await _context.TiposDocumentos.FindAsync(id) ?? new TipoDocumento();
        }
        public async Task<IEnumerable<LetraFactura>> GetAllLetraFacturaAsync()
        {
            return await _context.LetrasFacturas.ToListAsync();
        }
        public async Task<LetraFactura> GetLetraFacturaByIdAsync(int id)
        {
            var letraFactura = await _context.LetrasFacturas
                .Include(lf => lf.Facturas)
                .FirstOrDefaultAsync(lf => lf.IdLetraFactura == id);
            if (letraFactura != null)
            {
                return letraFactura;
            }
            else
            {
                throw new Exception("Letra de factura no encontrada");
            }
        }
        public async Task<IEnumerable<ConceptoFactura>> GetAllConceptoFacturaAsync()
        {
            return await _context.ConceptosFacturas.ToListAsync();
        }
        public async Task<ConceptoFactura> GetConceptoFacturaByIdAsync(int id)
        {
            var conceptoFactura = await _context.ConceptosFacturas
                .Include(cf => cf.Facturas)
                .FirstOrDefaultAsync(cf => cf.IdConceptoFactura == id);

            if (conceptoFactura != null)
            {
                return conceptoFactura;
            }
            else
            {
                throw new Exception("Concepto de factura no encontrado");
            }
        }
        public async Task<IEnumerable<FormaPago>> GetAllFormaPagoAsync()
        {
            return await _context.FormasPago.ToListAsync();
        }
        public async Task<FormaPago> GetFormaPagoByIdAsync(int id)
        {
            var formaPago = await _context.FormasPago
                .Include(fp => fp.Facturas)
                .FirstOrDefaultAsync(fp => fp.IdFormaPago == id);
            if (formaPago != null)
            {
                return formaPago;
            }
            else
            {
                throw new Exception("Forma de pago no encontrada");
            }
        }

        public async Task<IEnumerable<TipoDocumentoFiscal>> GetAllTipoDocumentoFiscalAsync()
        {
            return await _context.TiposDocumentosFiscales.ToListAsync();
        }

        public async Task<TipoDocumentoFiscal> GetTipoDocumentoFiscalByIdAsync(int id)
        {
            var tipoDocumentoFiscal = await _context.TiposDocumentosFiscales
                .Include(tdf => tdf.Facturas)
                .FirstOrDefaultAsync(tdf => tdf.IdTipoDocumentoFiscal == id);
            if (tipoDocumentoFiscal != null)
            {
                return tipoDocumentoFiscal;
            }
            else
            {
                throw new Exception("Tipo de documento fiscal no encontrado");
            }
        }

    }
}
