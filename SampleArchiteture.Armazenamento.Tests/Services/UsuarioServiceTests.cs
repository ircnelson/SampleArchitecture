using Autofac;
using NUnit.Framework;
using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Dominio.Repositories;
using SampleArchiteture.Dominio.Services;
using SampleArchiteture.Infraestrutura.Data;

namespace SampleArchiteture.Armazenamento.Tests.Services
{
    [SetUpFixture]
    public class UsuarioServiceTests : TestsBase
    {
        private IUnitOfWork _unitOfWork;
        private IUsuarioRepository _usuarioRepository;
        private UsuarioService _usuarioService;
        
        protected override void OnInit()
        {
            _unitOfWork = Container.Resolve<IUnitOfWork>();
            _usuarioRepository = Container.Resolve<IUsuarioRepository>();
            _usuarioService = Container.Resolve<UsuarioService>();
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
