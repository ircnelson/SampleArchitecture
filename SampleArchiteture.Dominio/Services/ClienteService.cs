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
    }
}
