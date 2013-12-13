using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using NUnit.Framework;
using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Dominio.Repositories;
using SampleArchiteture.Dominio.Services;
using SampleArchiteture.Infraestrutura.Data;

namespace SampleArchiteture.Infraestrutura.EntityFramework.Tests
{
    public class ClienteServiceTests
    {
        private IUnitOfWork _unitOfWork;
        private IClienteRepository _clienteRepository;
        private ClienteService _clienteService;
        private IContainer Container { get; set; }

        [SetUp]
        public void Setup()
        {
            IoC.IoC.Configure(new TestesModule());

            Container = IoC.IoC.Container;

            _unitOfWork = Container.Resolve<IUnitOfWork>();
            _clienteRepository = Container.Resolve<IClienteRepository>();
            _clienteService = Container.Resolve<ClienteService>();
        }

        [Test]
        public void DeveMarcarUmClienteParaReceberNovidades()
        {
            // arrange
            _clienteRepository.Add(new Cliente {Nome = "Chuck Norris"});
            _unitOfWork.Commit();

            // act
            var cliente = _clienteService.InscreverCliente(1);

            // assert
            Assert.AreEqual(true, cliente.RecebeNovidades);
            Assert.AreEqual(1, cliente.Id);
        }
    }
}
