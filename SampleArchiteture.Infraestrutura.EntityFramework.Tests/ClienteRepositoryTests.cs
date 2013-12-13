using Autofac;
using NUnit.Framework;
using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Dominio.Exceptions;
using SampleArchiteture.Dominio.Repositories;
using SampleArchiteture.Infraestrutura.Data;

namespace SampleArchiteture.Infraestrutura.EntityFramework.Tests
{
    public class ClienteRepositoryTests
    {
        private IUnitOfWork _unitOfWork;
        private IClienteRepository _clienteRepository;
        private IContainer Container { get; set; }

        [SetUp]
        public void Setup()
        {
            IoC.IoC.Configure(new TestesModule());

            Container = IoC.IoC.Container;

            _clienteRepository = Container.Resolve<IClienteRepository>();
            _unitOfWork = Container.Resolve<IUnitOfWork>();
        }

        [Test]
        public void DeveCadastrarUmCliente()
        {
            var cliente = CreateClienteFake();

            var clienteDoBancoDados = _clienteRepository.Get(1);

            Assert.AreEqual(cliente.Id, clienteDoBancoDados.Id);
        }

        [Test]
        public void DeveInativarUmCliente()
        {
            CreateClienteFake();

            var clienteDoBancoDados = _clienteRepository.Get(1);

            Assert.AreEqual(true, clienteDoBancoDados.Ativo);

            clienteDoBancoDados.Inativar();

            Assert.AreEqual(false, clienteDoBancoDados.Ativo);   
        }

        [Test]
        [ExpectedException(typeof (ClienteException))]
        public void NaoPodeInativarUmClienteInativo()
        {
            CreateClienteFake();

            var clienteDoBancoDados = _clienteRepository.Get(1);

            clienteDoBancoDados.Inativar();

            clienteDoBancoDados.Inativar();
        }

        private Cliente CreateClienteFake()
        {
            var cliente = new Cliente
            {
                Nome = "Nelson"
            };

            _clienteRepository.Add(cliente);

            _unitOfWork.Commit();

            return cliente;
        }
    }
}
