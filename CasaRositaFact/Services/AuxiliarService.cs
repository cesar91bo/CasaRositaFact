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
    }
}
