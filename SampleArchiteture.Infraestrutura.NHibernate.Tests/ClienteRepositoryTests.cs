using NUnit.Framework;

namespace SampleArchiteture.Infraestrutura.NHibernate.Tests
{
    public class ClienteRepositoryTests
    {
        [Test]
        public void DeveCadastrarUmCliente()
        {
            var cliente = CreateClienteFake();

            var clienteDoBancoDados = _clienteRepository.Get(1);

            Assert.AreEqual(cliente.Id, clienteDoBancoDados.Id);
        }
    }
}
