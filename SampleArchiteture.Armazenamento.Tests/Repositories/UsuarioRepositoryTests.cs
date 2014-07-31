using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Dominio.Repositories;
using SampleArchiteture.Infraestrutura.Data;

namespace SampleArchiteture.Armazenamento.Tests.Repositories
{
    [TestClass]
    public class UsuarioRepositoryTests : TestsBase
    {
        private IUnitOfWork _unitOfWork;
        private IUsuarioRepository _usuarioRepository;

        protected override void OnInit()
        {
            _usuarioRepository = Container.Resolve<IUsuarioRepository>();
            _unitOfWork = Container.Resolve<IUnitOfWork>();
        }

        [TestMethod]
        public void DeveCadastrarUmUsuario()
        {
            var usuario = CreateUsuarioFake();

            var usuarioDoBancoDados = _usuarioRepository.Get(1);

            Assert.AreEqual(usuario.Id, usuarioDoBancoDados.Id);
        }

        [TestMethod]
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

        [TestMethod]
        public void DeveRemoverUmUsuario()
        {
            CreateUsuarioFake();

            var usuarioDoBancoDados = _usuarioRepository.Get(1);

            _usuarioRepository.Remove(usuarioDoBancoDados);

            _unitOfWork.Commit();

            usuarioDoBancoDados = _usuarioRepository.Get(1);

            Assert.IsNull(usuarioDoBancoDados);
        }

        [TestMethod]
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