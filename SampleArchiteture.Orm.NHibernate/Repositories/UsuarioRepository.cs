using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Dominio.Repositories;

namespace SampleArchiteture.Orm.NHibernate.Repositories
{
    public class UsuarioRepository : Repository<Usuario, int>, IUsuarioRepository
    {
        public UsuarioRepository(ISession session) : base(session)
        {
        }

        public IEnumerable<Usuario> GetAtivos()
        {
            return Session.Query<Usuario>().Where(e => e.Ativo);
        }
    }
}