using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Infraestrutura.Data;

namespace SampleArchiteture.Persistencia.EntityFramework.Context
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

        public DbSet<Cliente> Clientes { get; set; }
        
        public void Commit()
        {
            SaveChanges();
        }
    }
}
