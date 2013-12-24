using System.Globalization;
using System.Threading;
using NUnit.Framework;
using SampleArchiteture.Dominio.Resources;

namespace SampleArchiteture.Dominio.Tests
{
    internal class I18nTests
    {
        [SetUICulture("en-US")]
        [Test]
        public void DeveTrazerMensagemEmIngles()
        {
            var message = Messages.UsuarioAtivo;

            Assert.AreEqual("User already activated.", message);
        }

        [Test]
        public void DeveTrazerMensagemEmPortugues()
        {
            Messages.Culture = new CultureInfo("pt-BR");

            var message = Messages.UsuarioAtivo;

            Assert.AreEqual("O usuário já está ativo.", message);
        }
    }
}
