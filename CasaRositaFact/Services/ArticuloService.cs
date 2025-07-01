using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;

namespace CasaRositaFact.Services
{
    public class ArticuloService
    {
        private readonly IArticuloRepository articuloRepository;

        public ArticuloService(IArticuloRepository articuloRepository)
        {
            this.articuloRepository = articuloRepository;
        }
        public Task<IEnumerable<Articulo>> GetAllAsync()
        {
            return articuloRepository.GetAllAsync();
        }
        public Task<Articulo> GetByIdAsync(int id)
        {
            return articuloRepository.GetByIdAsync(id);
        }
        public Task AddAsync(Articulo articulo)
        {
            return articuloRepository.AddAsync(articulo);
        }
        public Task UpdateAsync(Articulo articulo)
        {
            return articuloRepository.UpdateAsync(articulo);
        }
        public Task DeleteAsync(int id)
        {
            return articuloRepository.DeleteAsync(id);
        }
        public Task<IEnumerable<Articulo>> GetByCategoriaIdAsync(int categoriaId)
        {
            return articuloRepository.GetByCategoriaIdAsync(categoriaId);
        }
        public Task<IEnumerable<Articulo>> GetByRubroIdAsync(int rubroId)
        {
            return articuloRepository.GetByRubroIdAsync(rubroId);
        }
        public Task<IEnumerable<Articulo>> GetByProveedorIdAsync(int proveedorId)
        {
            return articuloRepository.GetByProveedorIdAsync(proveedorId);
        }
        public Task<IEnumerable<Articulo>> GetByUnidadMedidaIdAsync(int unidadMedidaId)
        {
            return articuloRepository.GetByUnidadMedidaIdAsync(unidadMedidaId);
        }
        public Task<IEnumerable<Articulo>> GetByNombreAsync(string nombre)
        {
            return articuloRepository.GetByNombreAsync(nombre);
        }
    }
}
