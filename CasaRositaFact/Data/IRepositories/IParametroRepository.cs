using CasaRositaFact.Data.Entities;

namespace CasaRositaFact.Data.IRepositories
{
    public interface IParametroRepository
    {
        Task<IEnumerable<Parametro>> GetAllParametrosAsync();
        Task<Parametro?> GetParametroByIdAsync(int id);
        Task AddParametroAsync(Parametro parametro);
        Task UpdateParametroAsync(Parametro parametro);
        Task DeleteParametroAsync(int id);
        Task<decimal> GetPorcentajeGanancia();
    }
}
