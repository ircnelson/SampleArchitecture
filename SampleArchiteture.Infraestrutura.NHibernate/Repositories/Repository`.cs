using System;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using SampleArchiteture.Dominio.Repositories;

namespace SampleArchiteture.Infraestrutura.NHibernate.Repositories
{
    /// <summary>
    /// Repositório genérico para NHibernate.
    /// </summary>
    /// <typeparam name="TEntity">Entidade</typeparam>
    /// <typeparam name="TKey">DataType da chave primária</typeparam>
    public class Repository<TEntity, TKey> : Repository, IRepository<TEntity, TKey>
        where TEntity : class
        where TKey : IComparable
    {
        public Repository(ISession session) : base(session)
        {
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
            if (entity == null)
                throw new ArgumentNullException("entity");

            Session.SaveOrUpdate(entity);
        }

        public void Remove(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            Session.Delete(entity);
        }

        public void Remove(TKey id)
        {
            var entity = Get(id);

            Session.Delete(entity);
        }
    }
}
