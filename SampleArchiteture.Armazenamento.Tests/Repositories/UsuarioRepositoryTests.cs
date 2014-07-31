using Autofac;
using NUnit.Framework;
using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Dominio.Repositories;
using SampleArchiteture.Infraestrutura.Data;

namespace SampleArchiteture.Armazenamento.Tests.Repositories
{
    [SetUpFixture]
    public class UsuarioRepositoryTests : TestsBase
    {
        private IUnitOfWork _unitOfWork;
        private IUsuarioRepository _usuarioRepository;

        protected override void OnInit()
        {
            _usuarioRepository = Container.Resolve<IUsuarioRepository>();
            _unitOfWork = Container.Resolve<IUnitOfWork>();
        }

        [Test]
        public void DeveCadastrarUmUsuario()
        {
            var usuario = CreateUsuarioFake();

            var usuarioDoBancoDados = _usuarioRepository.Get(1);

            Assert.AreEqual(usuario.Id, usuarioDoBancoDados.Id);
        }

        [Test]
        public void DeveInativarUmUsuario()
        {
            CreateUsuarioFake();

            var usuarioDoBancoDados = _usuarioRepository.Get(1);

            Assert.AreEqual(true, usuarioDoBancoDados.Ativo);

            usuarioDoBancoDados.Inativar();

            _unitOfWork.Commit();

            usuarioDoBancoDados = _usuarioRepository.Get(1);

            Assert.AreEqual(false, usuarioDoBancoDados.Ativo);   
        }

        [Test]
        public void DeveRemoverUmUsuario()
        {
            CreateUsuarioFake();

            var usuarioDoBancoDados = _usuarioRepository.Get(1);

            _usuarioRepository.Remove(usuarioDoBancoDados);

            _unitOfWork.Commit();

            usuarioDoBancoDados = _usuarioRepository.Get(1);

            Assert.IsNull(usuarioDoBancoDados);
        }

        [Test]
        public void DeveRemoverUmUsuarioPeloId()
        {
            CreateUsuarioFake();

            _usuarioRepository.Remove(1);

            _unitOfWork.Commit();

            var usuarioDoBancoDados = _usuarioRepository.Get(1);

            Assert.IsNull(usuarioDoBancoDados);
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