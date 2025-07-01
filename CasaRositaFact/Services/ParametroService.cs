using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;

namespace CasaRositaFact.Services
{
    public class ParametroService
    {
        private readonly IParametroRepository _parametroRepository;
        public ParametroService(IParametroRepository parametroRepository)
        {
            _parametroRepository = parametroRepository;
        }

        public Task<IEnumerable<Parametro>> GetAllParametrosAsync()
        {
            return _parametroRepository.GetAllParametrosAsync();
        }

        public Task<Parametro?> GetParametroByIdAsync(int id)
        {
            return _parametroRepository.GetParametroByIdAsync(id);
        }

        public Task AddParametroAsync(Parametro parametro)
        {
            return _parametroRepository.AddParametroAsync(parametro);
        }

        public Task UpdateParametroAsync(Parametro parametro)
        {
            return _parametroRepository.UpdateParametroAsync(parametro);
        }

        public Task DeleteParametroAsync(int id)
        {
            return _parametroRepository.DeleteParametroAsync(id);
        }

        public Task<decimal> GetPorcentajeGanancia()
        {
            return _parametroRepository.GetPorcentajeGanancia();
        }
    }
}
