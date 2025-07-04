﻿using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddClienteAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClienteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Cliente>> GetAllClienteAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.IdCliente == id);
            if (cliente == null)
                throw new Exception("Cliente no encontrado");
            return cliente;
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }
        public async Task<Cliente> GetClientePorDefecto()
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Nombre == "Consumidor");
            if (cliente == null)
                throw new Exception("Cliente por defecto no encontrado");
            return cliente;
        }
    }
}
