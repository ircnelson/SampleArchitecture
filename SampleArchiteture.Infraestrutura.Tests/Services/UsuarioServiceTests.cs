using Autofac;
using PJMT.Framework.DependencyInjection.Interfaces;
using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Dominio.Repositories;
using SampleArchiteture.Dominio.Services;
using SampleArchiteture.Infraestrutura.Data;
using Xunit;

namespace SampleArchiteture.Infraestrutura.Tests.Services
{
    public class UsuarioServiceTests
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly UsuarioService _usuarioService;

        public UsuarioServiceTests()
        {
            var container = SetupTest.Container;

            _unitOfWork = container.GetService<IUnitOfWork>();
            _usuarioRepository = container.GetService<IUsuarioRepository>();
            _usuarioService = container.GetService<UsuarioService>();
        }

        [Fact]
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
            Assert.Equal(true, usuario.RecebeNovidades);
            Assert.Equal(1, usuario.Id);
        }
    }
}
