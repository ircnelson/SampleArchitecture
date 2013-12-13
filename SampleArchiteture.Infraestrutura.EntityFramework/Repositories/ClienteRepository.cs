using System.Data.Entity;
using System.Linq;
using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Dominio.Repositories;

namespace SampleArchiteture.Infraestrutura.EntityFramework.Repositories
{
    public class ClienteRepository : Repository<Cliente, int>, IClienteRepository
    {
        public ClienteRepository(DbContext context) : base(context)
        {
        }

        public IQueryable<Cliente> GetAtivos()
        {
            return EntitySet.Where(e => e.Ativo);
        }
    }
}
