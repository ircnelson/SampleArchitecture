using Autofac;
using NUnit.Framework;
using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Dominio.Repositories;
using SampleArchiteture.Dominio.Services;
using SampleArchiteture.Infraestrutura.Data;

namespace SampleArchiteture.Infraestrutura.Tests.Services
{
    internal class UsuarioServiceTests
    {
        private IUnitOfWork _unitOfWork;
        private IUsuarioRepository _usuarioRepository;
        private UsuarioService _usuarioService;
        
        [SetUp]
        public void Setup()
        {
            var container = SetupTest.Container;

            _unitOfWork = container.Resolve<IUnitOfWork>();
            _usuarioRepository = container.Resolve<IUsuarioRepository>();
            _usuarioService = container.Resolve<UsuarioService>();
        }

        [Test]
        public void DeveMarcarUmUsuarioParaReceberNovidades()
        {
            // arrange
            _usuarioRepository.Add(new Usuario
            {
                Nome = "Chuck Norris"
            });

            _unitOfWork.Commit();

            // act
            var usuario = _usuarioService.InscreverUsuario(1);

            // assert
            Assert.AreEqual(true, usuario.RecebeNovidades);
            Assert.AreEqual(1, usuario.Id);
        }
    }
}
