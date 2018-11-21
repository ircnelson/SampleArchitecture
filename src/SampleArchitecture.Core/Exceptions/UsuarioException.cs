using SampleArchitecture.Core.Entities;

namespace SampleArchitecture.Core.Exceptions
{
    public class UsuarioException : BusinessException<Usuario>
    {
        public UsuarioException(Usuario target, string message, params object[] @params) : base(target, message, @params)
        {
        }

        public UsuarioException(Usuario target) : base(target)
        {
        }
    }
}