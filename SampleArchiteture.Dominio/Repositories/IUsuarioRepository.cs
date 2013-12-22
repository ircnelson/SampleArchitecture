using System.Linq;
using SampleArchiteture.Dominio.Entities;

namespace SampleArchiteture.Dominio.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario, int>
    {
        /// <summary>
        /// Retorna todas as entidades que estão ativas.
        /// </summary>
        /// <returns>Lista de usuario.</returns>
        IQueryable<Usuario> GetAtivos();
    }
}