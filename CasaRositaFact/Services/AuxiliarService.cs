using CasaRositaFact.Data.IRepositories;
using CasaRositaFact.Models;

namespace CasaRositaFact.Services
{
    public class AuxiliarService
    {
        private readonly IAuxiliarRepository auxiliarRepository;

        public AuxiliarService(IAuxiliarRepository auxiliarRepository)
        {
            this.auxiliarRepository = auxiliarRepository;
        }
        public async Task<IEnumerable<TipoDocumento>> GetAllTipoDocumentoAsync()
        {
            return await auxiliarRepository.GetAllTipoDocumentoAsync();
        }
        public async Task<TipoDocumento> GetTipoDocumentoByIdAsync(int id)
        {
            return await auxiliarRepository.GetTipoDocumentoByIdAsync(id);
        }
        public async Task<IEnumerable<LetraFactura>> GetAllLetraFacturaAsync()
        {
            return await auxiliarRepository.GetAllLetraFacturaAsync();
        }
        public async Task<LetraFactura> GetLetraFacturaByIdAsync(int id)
        {
            return await auxiliarRepository.GetLetraFacturaByIdAsync(id);
        }
        public async Task<IEnumerable<ConceptoFactura>> GetAllConceptoFacturaAsync()
        {
            return await auxiliarRepository.GetAllConceptoFacturaAsync();
        }
        public async Task<ConceptoFactura> GetConceptoFacturaByIdAsync(int id)
        {
            return await auxiliarRepository.GetConceptoFacturaByIdAsync(id);
        }
        public async Task<IEnumerable<FormaPago>> GetAllFormaPagoAsync()
        {
            return await auxiliarRepository.GetAllFormaPagoAsync();
        }
        public async Task<FormaPago> GetFormaPagoByIdAsync(int id)
        {
            return await auxiliarRepository.GetFormaPagoByIdAsync(id);
        }
        public async Task<IEnumerable<TipoDocumentoFiscal>> GetAllTipoDocumentoFiscalAsync()
        {
            return await auxiliarRepository.GetAllTipoDocumentoFiscalAsync();
        }
        public async Task<TipoDocumentoFiscal> GetTipoDocumentoFiscalByIdAsync(int id)
        {
            return await auxiliarRepository.GetTipoDocumentoFiscalByIdAsync(id);
        }
    }
}
