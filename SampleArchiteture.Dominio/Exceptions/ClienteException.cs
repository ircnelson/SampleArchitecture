using System;
using SampleArchiteture.Dominio.Entities;

namespace SampleArchiteture.Dominio.Exceptions
{
    public class ClienteException : Exception
    {
        public Cliente Cliente { get; private set; }

        public ClienteException(string message) : base(message)
        {
        }

        public ClienteException(Cliente cliente) : base(cliente.ToString())
        {
            Cliente = cliente;
        }

        public ClienteException(string message, Cliente cliente) : base(message, new ClienteException(cliente))
        {
        }
    }
}
