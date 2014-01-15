using System;
using SampleArchiteture.Dominio.Entities;

namespace SampleArchiteture.Dominio.Exceptions
{
    public class UsuarioException : Exception<Usuario>
    {
        public UsuarioException(Usuario target, string message, params object[] @params) : base(target, message, @params)
        {
        }

        public UsuarioException(Usuario target) : base(target)
        {
        }
    }
}
