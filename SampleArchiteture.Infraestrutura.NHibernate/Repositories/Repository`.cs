using System;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using SampleArchiteture.Dominio.Repositories;

namespace SampleArchiteture.Infraestrutura.NHibernate.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class
        where TKey : IComparable
    {
        private readonly ISession _session;

        protected ISession Session
        {
            get
            {
                return _session;
            }
        }

        public Repository(ISession session)
        {
            _session = session;
        }

        public TEntity Get(TKey id)
        {
            return Session.Get<TEntity>(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Session.Query<TEntity>();
        }

        public void Add(TEntity entity)
        {
            Session.SaveOrUpdate(entity);
        }

        public void Remove(TEntity entity)
        {
            Session.Delete(entity);
        }

        public void Remove(TKey id)
        {
            var entity = Get(id);

            Session.Delete(entity);
        }
    }
}
