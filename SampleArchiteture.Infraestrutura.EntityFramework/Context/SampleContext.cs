using System.Data.Common;
using System.Data.Entity;
using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Infraestrutura.Data;

namespace SampleArchiteture.Infraestrutura.EntityFramework.Context
{
    public class SampleContext : DbContext, IUnitOfWork
    {
        public SampleContext()
            : base("name=SampleContext")
        {
        }

        public SampleContext(string connectionString) : base(connectionString)
        {
        }

        public SampleContext(DbConnection connection) : base(connection, true)
        {
        }

        private IDbSet<Cliente> Clientes { get; set; }

        public void Commit()
        {
            SaveChanges();
        }
    }
}
