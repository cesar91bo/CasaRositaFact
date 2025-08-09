using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public ArticuloRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<Articulo>> GetAllAsync()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Articulos
                .AsNoTracking()
                .Include(a => a.Categoria)
                .Include(a => a.Rubro)
                .Include(a => a.UnidadMedida)
                .Include(a => a.Proveedor)
                .Include(a => a.PreciosArticulos)
                .ToListAsync();
        }

        public async Task<Articulo> GetByIdAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();

            // Trae el artículo sin tracking (lectura)
            var articulo = await db.Articulos
                .AsNoTracking()
                .Include(a => a.Categoria)
                .Include(a => a.Rubro)
                .Include(a => a.UnidadMedida)
                .Include(a => a.Proveedor)
                .Include(a => a.PreciosArticulos)
                .FirstOrDefaultAsync(a => a.IdArticulo == id);

            if (articulo == null)
                throw new Exception("Artículo no encontrado");

            // Calcula el precio actual sin requerir tracking
            var precioActual = articulo.PreciosArticulos
                .OrderByDescending(p => p.FechaIncio)   // ajustá el campo si corresponde
                .FirstOrDefault()?.PrecioVentaConIva;

            articulo.PrecioActual = precioActual ?? 0m;

            return articulo;
        }

        public async Task AddAsync(Articulo articulo)
        {
            await using var db = await _factory.CreateDbContextAsync();
            db.Articulos.Add(articulo);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Articulo articulo)
        {
            await using var db = await _factory.CreateDbContextAsync();
            db.Articulos.Update(articulo);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();

            // Si la PK es IdArticulo:
            var articulo = await db.Articulos.FirstOrDefaultAsync(a => a.IdArticulo == id);
            // (Si tu PK se llama distinto y tenés configurado Find, podrías usar: var articulo = await db.Articulos.FindAsync(id);)

            if (articulo == null)
                throw new Exception("Articulo no encontrado");

            db.Articulos.Remove(articulo);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Articulo>> GetByCategoriaIdAsync(int categoriaId)
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Articulos
                .AsNoTracking()
                .Include(a => a.Categoria)
                .Where(a => a.IdCategoria == categoriaId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Articulo>> GetByRubroIdAsync(int rubroId)
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Articulos
                .AsNoTracking()
                .Include(a => a.Rubro)
                .Where(a => a.IdRubro == rubroId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Articulo>> GetByProveedorIdAsync(int proveedorId)
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Articulos
                .AsNoTracking()
                .Include(a => a.Proveedor)
                .Where(a => a.IdProveedor == proveedorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Articulo>> GetByUnidadMedidaIdAsync(int unidadMedidaId)
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Articulos
                .AsNoTracking()
                .Include(a => a.UnidadMedida)
                .Where(a => a.IdUnidadMedida == unidadMedidaId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Articulo>> GetByNombreAsync(string nombre)
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Articulos
                .AsNoTracking()
                .Include(a => a.Categoria)
                .Include(a => a.Rubro)
                .Include(a => a.UnidadMedida)
                .Include(a => a.Proveedor)
                .Where(a => a.Nombre.Contains(nombre))
                .ToListAsync();
        }
    }
}
