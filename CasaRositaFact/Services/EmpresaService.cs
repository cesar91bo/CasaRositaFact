using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;

namespace CasaRositaFact.Services
{
    public class EmpresaService
    {
        private readonly IEmpresaRepository empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            this.empresaRepository = empresaRepository;
        }
        public Task<IEnumerable<Empresa>> GetAllAsync()
        {
            return empresaRepository.GetAllAsync();
        }
        public Task<Empresa> GetByIdAsync(int id)
        {
            return empresaRepository.GetByIdAsync(id);
        }
        public Task AddAsync(Empresa empresa)
        {
            return empresaRepository.AddAsync(empresa);
        }
        public Task UpdateAsync(Empresa empresa)
        {
            return empresaRepository.UpdateAsync(empresa);
        }
        public Task DeleteAsync(int id)
        {
            return empresaRepository.DeleteAsync(id);
        }
    }
}
