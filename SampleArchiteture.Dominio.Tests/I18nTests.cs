using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleArchiteture.Dominio.Resources;
using System.Globalization;
using System.Threading;

namespace SampleArchiteture.Dominio.Tests
{
    [TestClass]
    public class I18nTests
    {
        [TestMethod]
        public void DeveTrazerMensagemEmIngles()
        {
            Assert.AreEqual(System.Threading.Thread.CurrentThread.CurrentUICulture.ToString(), "en-US");

            var message = Messages.UsuarioAtivo;

            Assert.AreEqual("User already activated.", message);
        }

        [TestMethod]
        public void DeveTrazerMensagemEmPortugues()
        {
            Assert.AreEqual(System.Threading.Thread.CurrentThread.CurrentUICulture.ToString(), "en-US");

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
            Messages.Culture = Thread.CurrentThread.CurrentUICulture;

            var message = Messages.UsuarioAtivo;

            Assert.AreEqual("O usuário já está ativo.", message);
        }
    }
}
