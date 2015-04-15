using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Dominio.Exceptions;
using Xunit;

namespace SampleArchiteture.Dominio.Tests
{
    public class UsuarioTests
    {
        [Fact]
        public void NaoDeveInativarUmUsuarioInativo()
        {
            Assert.Throws<UsuarioException>(() =>
            {
                var usuario = new Usuario
                {
                    Nome = "Fakeman"
                };

                usuario.Inativar();

                usuario.Inativar();
            });
        }
    }
}
