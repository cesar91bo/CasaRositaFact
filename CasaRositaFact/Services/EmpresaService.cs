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
        public Task<IEnumerable<Models.Empresa>> GetAllAsync()
        {
            return empresaRepository.GetAllAsync();
        }
        public Task<Models.Empresa> GetByIdAsync(int id)
        {
            return empresaRepository.GetByIdAsync(id);
        }
        public Task AddAsync(Models.Empresa empresa)
        {
            return empresaRepository.AddAsync(empresa);
        }
        public Task UpdateAsync(Models.Empresa empresa)
        {
            return empresaRepository.UpdateAsync(empresa);
        }
        public Task DeleteAsync(int id)
        {
            return empresaRepository.DeleteAsync(id);
        }
    }
}
