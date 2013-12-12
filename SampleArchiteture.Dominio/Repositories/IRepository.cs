using System.Collections.Generic;
using System.Linq;

namespace SampleArchiteture.Dominio.Repositories
{
    public interface IRepository<TEntity, in TKey>
        where TEntity : class
    {
        TEntity Get(TKey id);

        IQueryable<TEntity> GetAll();

        void Add(TEntity entity);
    }
}