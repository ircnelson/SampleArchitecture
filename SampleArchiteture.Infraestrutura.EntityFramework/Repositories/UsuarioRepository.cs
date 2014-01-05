using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Dominio.Repositories;

namespace SampleArchiteture.Infraestrutura.EntityFramework.Repositories
{
    public class UsuarioRepository : Repository<Usuario, int>, IUsuarioRepository
    {
        public UsuarioRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Usuario> GetAtivos()
        {
            return EntitySet.Where(e => e.Ativo);
        }
    }
}
