using Autofac;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace SampleArchiteture.Infraestrutura.Tests
{
    internal class NHibernateModule : NHibernate.StartupModule
    {
        public NHibernateModule()
        {
            PersistenceConfigurer = SQLiteConfiguration.Standard.InMemory().ShowSql();
            OnSessionActivating = a => new SchemaExport(a.Context.Resolve<Configuration>()).Execute(true, true, false, a.Instance.Connection, null);
        }
    }
}
