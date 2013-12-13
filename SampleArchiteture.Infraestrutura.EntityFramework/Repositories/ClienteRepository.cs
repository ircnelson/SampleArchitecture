using System.Data.Entity;
using System.Linq;
using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Dominio.Repositories;

namespace SampleArchiteture.Infraestrutura.EntityFramework.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DbSet<Cliente> _dbSet;

        public ClienteRepository(DbContext context)
        {
            _dbSet = context.Set<Cliente>();
        }
        
        public Cliente Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<Cliente> GetAll()
        {
            return _dbSet;
        }

        public void Add(Cliente entity)
        {
            _dbSet.Add(entity);
        }

        public void Remove(Cliente entity)
        {
            _dbSet.Remove(entity);
        }

        public void Remove(int id)
        {
            var entity = _dbSet.Find(id);
            
            if (entity != null)
                Remove(entity);
        }

        public IQueryable<Cliente> GetAtivos()
        {
            return _dbSet.Where(e => e.Ativo);
        }
    }
}
