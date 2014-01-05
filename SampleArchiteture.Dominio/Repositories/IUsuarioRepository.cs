using System.Collections.Generic;
using SampleArchiteture.Dominio.Entities;

namespace SampleArchiteture.Dominio.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario, int>, IReadOnlyRepository<Usuario, int>
    {
        /// <summary>
        /// Retorna todas as entidades que estão ativas.
        /// </summary>
        /// <returns>Lista de usuario.</returns>
        IEnumerable<Usuario> GetAtivos();
    }
}