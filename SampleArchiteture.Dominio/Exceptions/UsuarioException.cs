using System;
using SampleArchiteture.Dominio.Entities;

namespace SampleArchiteture.Dominio.Exceptions
{
    public class UsuarioException : Exception
    {
        public Usuario Usuario { get; private set; }

        public UsuarioException(string message) : base(message)
        {
        }

        public UsuarioException(Usuario usuario) : base(usuario.ToString())
        {
            Usuario = usuario;
        }

        public UsuarioException(string message, Usuario usuario) : base(message, new UsuarioException(usuario))
        {
        }
    }
}
