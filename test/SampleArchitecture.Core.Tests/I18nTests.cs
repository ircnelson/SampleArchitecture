using System.Globalization;
using System.Threading;
using FluentAssertions;
using SampleArchitecture.Core.Resources;
using Xunit;

namespace SampleArchitecture.Core.Tests
{
    public class I18nTests
    {
        [Fact]
        public void Deve_trazer_mensagem_em_EnUs()
        {
            var message = Messages.UsuarioAtivo;
            
            message.Should().Be("User already activated.");
        }
        
        [Fact]
        public void Deve_trazer_mensagem_em_PtBr()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
            
            var message = Messages.UsuarioAtivo;
            
            message.Should().Be("O usuário já está ativo.");
        }
    }
}