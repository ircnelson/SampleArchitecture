using Autofac;
using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Dominio.Repositories;
using SampleArchiteture.Infraestrutura.Data;
using Xunit;

namespace SampleArchiteture.Infraestrutura.Tests.Repositories
{
    public class UsuarioRepositoryTests
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioRepositoryTests()
        {
            var container = SetupTest.Container;

            _usuarioRepository = container.Resolve<IUsuarioRepository>();
            _unitOfWork = container.Resolve<IUnitOfWork>();
        }

        [Fact]
        public void DeveCadastrarUmUsuario()
        {
            var usuario = CreateUsuarioFake();

            var usuarioDoBancoDados = _usuarioRepository.Get(1);

            Assert.Equal(usuario.Id, usuarioDoBancoDados.Id);
        }

        [Fact]
        public void DeveInativarUmUsuario()
        {
            CreateUsuarioFake();

            var usuarioDoBancoDados = _usuarioRepository.Get(1);

            Assert.Equal(true, usuarioDoBancoDados.Ativo);

            usuarioDoBancoDados.Inativar();

            _unitOfWork.Commit();

            usuarioDoBancoDados = _usuarioRepository.Get(1);

            Assert.Equal(false, usuarioDoBancoDados.Ativo);   
        }

        [Fact]
        public void DeveRemoverUmUsuario()
        {
            CreateUsuarioFake();

            var usuarioDoBancoDados = _usuarioRepository.Get(1);

            _usuarioRepository.Remove(usuarioDoBancoDados);

            _unitOfWork.Commit();

            usuarioDoBancoDados = _usuarioRepository.Get(1);

            Assert.Null(usuarioDoBancoDados);
        }

        [Fact]
        public void DeveRemoverUmUsuarioPeloId()
        {
            CreateUsuarioFake();

            _usuarioRepository.Remove(1);

            _unitOfWork.Commit();

            var usuarioDoBancoDados = _usuarioRepository.Get(1);

            Assert.Null(usuarioDoBancoDados);
        }

        private Usuario CreateUsuarioFake()
        {
            var usuario = new Usuario();

            _usuarioRepository.Add(usuario);

            _unitOfWork.Commit();

            return usuario;
        }
    }
}