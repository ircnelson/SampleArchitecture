using System.Linq;
using NHibernate;
using NHibernate.Linq;
using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Dominio.Repositories;

namespace SampleArchiteture.Infraestrutura.NHibernate.Repositories
{
    public class ClienteRepository : Repository<Cliente, int>, IClienteRepository
    {
        public ClienteRepository(ISession session) : base(session)
        {
        }

        public IQueryable<Cliente> GetAtivos()
        {
            return Session.Query<Cliente>().Where(e => e.Ativo);
        }
    }
}
