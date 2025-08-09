using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public ClienteRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task AddClienteAsync(Cliente cliente)
        {
            await using var db = await _factory.CreateDbContextAsync();
            db.Clientes.Add(cliente);
            await db.SaveChangesAsync();
        }

        public async Task DeleteClienteAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();

            // Si la PK es IdCliente:
            var cliente = await db.Clientes.FirstOrDefaultAsync(c => c.IdCliente == id);
            // Si la PK es Id y FindAsync funciona, podrías usar: var cliente = await db.Clientes.FindAsync(id);

            if (cliente is null) return;

            db.Clientes.Remove(cliente);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cliente>> GetAllClienteAsync()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Clientes
                           .AsNoTracking()
                           .OrderBy(c => c.Nombre)
                           .ToListAsync();
        }

        public async Task<Cliente?> GetClienteByIdAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Clientes
                           .AsNoTracking()
                           .FirstOrDefaultAsync(c => c.IdCliente == id);
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            await using var db = await _factory.CreateDbContextAsync();
            db.Clientes.Update(cliente);
            await db.SaveChangesAsync();
        }

        public async Task<Cliente?> GetClientePorDefecto()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Clientes
                           .AsNoTracking()
                           .FirstOrDefaultAsync(c => c.Nombre == "Consumidor");
        }
    }
}
