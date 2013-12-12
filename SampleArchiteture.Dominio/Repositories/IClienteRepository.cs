using System.Linq;
using SampleArchiteture.Dominio.Entities;

namespace SampleArchiteture.Dominio.Repositories
{
    public interface IClienteRepository : IRepository<Cliente, int>
    {
        IQueryable<Cliente> GetAtivos();
    }
}