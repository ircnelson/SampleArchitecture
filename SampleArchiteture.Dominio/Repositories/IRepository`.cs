using System;
using System.Linq;

namespace SampleArchiteture.Dominio.Repositories
{
    public interface IRepository<TEntity, in TKey>
        where TEntity : class
        where TKey : struct, IComparable
    {
        /// <summary>
        /// Adiciona <typeparamref name="TEntity"/> em um repositório de dados.
        /// </summary>
        /// <param name="entity">entidade a ser armazenada</param>
        void Add(TEntity entity);

        /// <summary>
        /// Retira <typeparamref name="TEntity"/> do repositório de dados.
        /// </summary>
        /// <param name="entity">entidade a ser retirada</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Retira <typeparamref name="TEntity"/> do repositório de dados através da identificação única.
        /// </summary>
        /// <param name="id">Identificação única</param>
        void Remove(TKey id);
    }
}