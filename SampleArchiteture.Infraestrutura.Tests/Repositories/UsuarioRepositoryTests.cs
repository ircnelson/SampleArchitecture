using Autofac;
using NUnit.Framework;
using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Dominio.Exceptions;
using SampleArchiteture.Dominio.Repositories;
using SampleArchiteture.Infraestrutura.Data;

namespace SampleArchiteture.Infraestrutura.Tests.Repositories
{
    public class UsuarioRepositoryTests
    {
        private IUnitOfWork _unitOfWork;
        private IUsuarioRepository _usuarioRepository;

        [SetUp]
        public void Setup()
        {
            var container = SetupTest.Container;

            _usuarioRepository = container.Resolve<IUsuarioRepository>();
            _unitOfWork = container.Resolve<IUnitOfWork>();
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
        [ExpectedException(typeof (UsuarioException))]
        public void NaoPodeInativarUmUsuarioInativo()
        {
            CreateUsuarioFake();

            var usuarioDoBancoDados = _usuarioRepository.Get(1);

            usuarioDoBancoDados.Inativar();

            usuarioDoBancoDados.Inativar();
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
            var usuario = new Usuario
            {
                Nome = "Nelson"
            };

            _usuarioRepository.Add(usuario);

            _unitOfWork.Commit();

            return usuario;
        }
    }
}
