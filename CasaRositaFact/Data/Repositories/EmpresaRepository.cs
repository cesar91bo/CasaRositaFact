using CasaRositaFact.Data.IRepositories;
using CasaRositaFact.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly ApplicationDbContext context;

        public EmpresaRepository(ApplicationDbContext context) 
        {
            this.context = context;
        }
        public async Task AddAsync(Empresa empresa)
        {
            context.Empresas.Add(empresa);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var empresa = await context.Empresas.FindAsync(id);
            if (empresa != null)
            {
                context.Empresas.Remove(empresa);
                await context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Empresa>> GetAllAsync()
        {
            return await context.Empresas.ToListAsync();
        }
        public async Task<Empresa> GetByIdAsync(int id)
        {
            var empresa = await context.Empresas.FirstOrDefaultAsync(e => e.IdEmpresa == id);
            if (empresa == null)
                throw new Exception("Empresa no encontrada");
            return empresa;
        }
        public async Task UpdateAsync(Empresa empresa)
        {
            context.Empresas.Update(empresa);
            await context.SaveChangesAsync();
        }
    }
}
