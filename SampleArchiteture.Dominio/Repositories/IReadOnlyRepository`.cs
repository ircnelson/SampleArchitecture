using System;
using System.Collections.Generic;

namespace SampleArchiteture.Dominio.Repositories
{
    /// <summary>
    /// Interface somente para leitura dos dados.
    /// </summary>
    /// <typeparam name="TEntity">Entidade</typeparam>
    /// <typeparam name="TKey">Identificador único</typeparam>
    public interface IReadOnlyRepository<out TEntity, in TKey>
        where TEntity : class
        where TKey : struct, IComparable
    {
        /// <summary>
        /// Retorna <typeparamref name="TEntity"/> através da identificação única.
        /// </summary>
        /// <param name="id">Identificação única</param>
        /// <returns><typeparam name="TEntity"></typeparam>.</returns>
        TEntity Get(TKey id);

        /// <summary>
        /// Retorna uma coleção do tipo <typeparamref name="TEntity"/>.
        /// </summary>
        /// <returns>coleçao de <typeparamref name="TEntity"/>.</returns>
        IEnumerable<TEntity> GetAll();
    }
}