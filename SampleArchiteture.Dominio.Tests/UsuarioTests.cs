using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Dominio.Exceptions;
using System;

namespace SampleArchiteture.Dominio.Tests
{
    [TestClass]
    public class UsuarioTests
    {
        [TestMethod]
        [ExpectedException(typeof(UsuarioException))]
        public void NaoDeveInativarUmUsuarioInativo()
        {
            var usuario = new Usuario
            {
                Nome = "Fakeman"
            };

            usuario.Inativar();

            usuario.Inativar();
        }
    }
}
