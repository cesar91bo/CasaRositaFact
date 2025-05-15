using CasaRositaFact.Models;

namespace CasaRositaFact.Data.IRepositories
{
    public interface IAuxiliarRepository
    {
        Task<IEnumerable<TipoDocumento>> GetAllTipoDocumentoAsync();
        Task<TipoDocumento> GetTipoDocumentoByIdAsync(int id);

        Task<IEnumerable<TipoDocumentoFiscal>> GetAllTipoDocumentoFiscalAsync();
        Task<TipoDocumentoFiscal> GetTipoDocumentoFiscalByIdAsync(int id);

        Task<IEnumerable<LetraFactura>> GetAllLetraFacturaAsync();
        Task<LetraFactura> GetLetraFacturaByIdAsync(int id);

        Task<IEnumerable<ConceptoFactura>> GetAllConceptoFacturaAsync();
        Task<ConceptoFactura> GetConceptoFacturaByIdAsync(int id);

        Task<IEnumerable<FormaPago>> GetAllFormaPagoAsync();
        Task<FormaPago> GetFormaPagoByIdAsync(int id);
    }
}
