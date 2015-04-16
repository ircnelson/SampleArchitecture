using System.Globalization;
using System.Threading;
using SampleArchiteture.Dominio.Resources;
using Xunit;

namespace SampleArchiteture.Dominio.Tests
{
    public class I18nTests
    {
        private void SetCultureInfo(string culture = "en-US")
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        }

        [Fact]
        public void DeveTrazerMensagemEmIngles()
        {
            SetCultureInfo();

            var message = Messages.UsuarioAtivo;

            Assert.Equal("User already activated.", message);
        }

        [Fact]
        public void DeveTrazerMensagemEmPortugues()
        {
            SetCultureInfo();

            Messages.Culture = new CultureInfo("pt-BR");

            var message = Messages.UsuarioAtivo;

            Assert.Equal("O usuário já está ativo.", message);
        }
    }
}
