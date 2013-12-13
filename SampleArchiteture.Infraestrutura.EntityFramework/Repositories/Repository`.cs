using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleArchiteture.Dominio.Repositories;

namespace SampleArchiteture.Infraestrutura.EntityFramework.Repositories
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity,  TKey>
        where TEntity : class
        where TKey : IComparable
    {

        private DbSet<TEntity> _entitySet;

        private readonly DbContext _context;

        protected DbSet<TEntity> EntitySet
        {
            get
            {
                return _entitySet ?? (_entitySet = _context.Set<TEntity>());
            }
        }

        protected Repository(DbContext context)
        {
            _context = context;
        }

        public TEntity Get(TKey id)
        {
            return EntitySet.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return EntitySet;
        }

        public void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            EntitySet.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            EntitySet.Remove(entity);
        }

        public void Remove(TKey id)
        {
            if (id == null)
                throw new ArgumentNullException("id");

            var entity = EntitySet.Find(id);

            Remove(entity);
        }
    }
}
