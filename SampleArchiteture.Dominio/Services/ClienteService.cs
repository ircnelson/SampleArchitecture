using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Dominio.Repositories;

namespace SampleArchiteture.Dominio.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente InscreverCliente(int id)
        {
            var cliente = _clienteRepository.Get(id);

            cliente.RecebeNovidades = true;

            return cliente;
        }
    }
}
