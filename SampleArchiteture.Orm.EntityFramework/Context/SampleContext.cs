using System.Data.Common;
using System.Data.Entity;
using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Infraestrutura.Data;

namespace SampleArchiteture.Orm.EntityFramework.Context
{
    public class SampleContext : DbContext, IUnitOfWork
    {
        public SampleContext()
        {
        }

        public SampleContext(string connectionString) : base(connectionString)
        {
        }

        public SampleContext(DbConnection connection) : base(connection, true)
        {
        }

        protected IDbSet<Usuario> Usuarios { get; set; }

        public void Commit()
        {
            SaveChanges();
        }
    }
}
