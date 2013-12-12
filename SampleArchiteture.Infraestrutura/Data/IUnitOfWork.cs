using System;

namespace SampleArchiteture.Infraestrutura.Data
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Realiza a confirmação dos objetos em transação.
        /// </summary>
        void Commit();
    }
}