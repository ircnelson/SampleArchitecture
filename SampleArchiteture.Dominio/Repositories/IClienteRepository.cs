using System.Linq;
using SampleArchiteture.Dominio.Entities;

namespace SampleArchiteture.Dominio.Repositories
{
    public interface IClienteRepository : IRepository<Cliente, int>
    {
        /// <summary>
        /// Retorna todas as entidades que estão ativas.
        /// </summary>
        /// <returns>Lista de cliente.</returns>
        IQueryable<Cliente> GetAtivos();
    }
}