using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly ApplicationDbContext _context;
        public ArticuloRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Articulo>> GetAllAsync()
        {
            return await _context.Articulos
                .Include(a => a.Categoria)
                .Include(a => a.Rubro)
                .Include(a => a.UnidadMedida)
                .Include(a => a.Proveedor)
                .Include(a => a.PreciosArticulos)

                .ToListAsync();
        }
        public async Task<Articulo> GetByIdAsync(int id)
        {
            var articulo = await _context.Articulos
                .Include(a => a.Categoria)
                .Include(a => a.Rubro)
                .Include(a => a.UnidadMedida)
                .Include(a => a.Proveedor)
                .Include(a => a.PreciosArticulos)
                .FirstOrDefaultAsync(a => a.IdArticulo == id);
            if (articulo == null)
                throw new Exception("Artículo no encontrado");

            // Obtener el último precio (por fecha o por ID, lo que uses)
            var precioActual = articulo.PreciosArticulos
                .OrderByDescending(p => p.FechaIncio) // o por ID si no tenés fecha
                .FirstOrDefault()?.PrecioVentaConIva;

            // Asignar a una propiedad auxiliar (si tenés una en el modelo)
            articulo.PrecioActual = precioActual ?? 0;

            return articulo;
        }
        public async Task AddAsync(Articulo articulo)
        {
            _context.Articulos.Add(articulo);
            await _context.SaveChangesAsync();
        }
        public Task UpdateAsync(Articulo articulo)
        {
            _context.Articulos.Update(articulo);
            return _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo != null)
            {
                _context.Articulos.Remove(articulo);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Articulo no encontrado");
            }
        }
        public async Task<IEnumerable<Articulo>> GetByCategoriaIdAsync(int categoriaId)
        {
            return await _context.Articulos
                .Include(a => a.Categoria)
                .Where(a => a.IdCategoria == categoriaId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Articulo>> GetByRubroIdAsync(int rubroId)
        {
            return await _context.Articulos
                .Include(a => a.Rubro)
                .Where(a => a.IdRubro == rubroId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Articulo>> GetByProveedorIdAsync(int proveedorId)
        {
            return await _context.Articulos
                .Include(a => a.Proveedor)
                .Where(a => a.IdProveedor == proveedorId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Articulo>> GetByUnidadMedidaIdAsync(int unidadMedidaId)
        {
            return await _context.Articulos
                .Include(a => a.UnidadMedida)
                .Where(a => a.IdUnidadMedida == unidadMedidaId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Articulo>> GetByNombreAsync(string nombre)
        {
            return await _context.Articulos
                .Include(a => a.Categoria)
                .Include(a => a.Rubro)
                .Include(a => a.UnidadMedida)
                .Include(a => a.Proveedor)
                .Where(a => a.Nombre.Contains(nombre))
                .ToListAsync();
        }
    }
}
