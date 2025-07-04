﻿using CasaRositaFact.Data.Entities;
using CasaRositaFact.Data.IRepositories;

namespace CasaRositaFact.Services
{
    public class ClienteService
    {
        public readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            return _clienteRepository.GetAllClienteAsync();
        }
        public Task<Cliente> GetClienteByIdAsync(int id)
        {
            return _clienteRepository.GetClienteByIdAsync(id);
        }
        public Task AddClienteAsync(Cliente cliente)
        {
            return _clienteRepository.AddClienteAsync(cliente);
        }
        public Task UpdateClienteAsync(Cliente cliente)
        {
            return _clienteRepository.UpdateClienteAsync(cliente);
        }
        public Task DeleteClienteAsync(int id)
        {
            return _clienteRepository.DeleteClienteAsync(id);
        }
        public Task<Cliente> GetClientePorDefecto()
        {
            return _clienteRepository.GetClientePorDefecto();
        }
    }
}
