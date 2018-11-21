using System;
using FluentAssertions;
using SampleArchitecture.Core.Entities;
using SampleArchitecture.Core.Exceptions;
using Xunit;

namespace SampleArchitecture.Core.Tests
{
    public class UsuarioTests
    {
        [Fact]
        public void Nao_deve_inativar_um_usuario_inativo()
        {
            var usuario = new Usuario
            {
                Nome = "Fakeman"
            };

            usuario.Inativar();

            Action act = () => usuario.Inativar();

            act.Should().ThrowExactly<UsuarioException>();
        }
    }
}