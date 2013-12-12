using System;
using System.Data.Common;
using System.Data.Entity;
using Effort;
using NUnit.Framework;
using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Dominio.Exceptions;
using SampleArchiteture.Dominio.Repositories;
using SampleArchiteture.Infraestrutura.Data;
using SampleArchiteture.Persistencia.EntityFramework.Context;
using SampleArchiteture.Persistencia.EntityFramework.Repositories;

namespace SampleArchiteture.Persistencia.EntityFramework.Tests
{
    public class ClienteRepositoryTests
    {
        private SampleContext _context;
        private IClienteRepository _clienteRepository;

        [SetUp]
        public void Setup()
        {
            DbConnection dbConnection = DbConnectionFactory.CreateTransient();
            _context = new SampleContext(dbConnection);
            _clienteRepository = new ClienteRepository(_context);
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

            _context.Commit();

            return cliente;
        }
    }
}
