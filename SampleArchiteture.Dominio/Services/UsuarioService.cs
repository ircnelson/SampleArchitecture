using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Dominio.Repositories;

namespace SampleArchiteture.Dominio.Services
{
    public class UsuarioService : IServiceBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario InscreverUsuario(int id)
        {
            var usuario = _usuarioRepository.Get(id);

            usuario.RecebeNovidades = true;

            return usuario;
        }
    }
}
