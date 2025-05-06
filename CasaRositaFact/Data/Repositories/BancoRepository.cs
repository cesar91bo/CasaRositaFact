using CasaRositaFact.Data.IRepositories;
using CasaRositaFact.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class BancoRepository : IBancoRepository
    {
        private readonly ApplicationDbContext _context;

        public BancoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddBancoAsync(Banco banco)
        {
            _context.Bancos.Add(banco);
            return _context.SaveChangesAsync();
        }

        public Task DeleteBancoAsync(int id)
        {
            var banco = _context.Bancos.Find(id);
            if (banco != null)
            {
                _context.Bancos.Remove(banco);
                return _context.SaveChangesAsync();
            }
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Banco>> GetAllBancosAsync()
        {
            return await _context.Bancos
                .Include(b => b.Proveedores)
                .ToListAsync();
        }

        public async Task<Banco?> GetBancoByIdAsync(int id)
        {
            return await _context.Bancos
                .Include(b => b.Proveedores)
                .FirstOrDefaultAsync(b => b.IdBanco == id);
        }

        public Task UpdateBancoAsync(Banco banco)
        {
            _context.Bancos.Update(banco);
            return _context.SaveChangesAsync();
        }
    }
}
