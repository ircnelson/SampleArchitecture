using Autofac;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using SampleArchiteture.Infraestrutura.NHibernate;
using SampleArchiteture.Infraestrutura.NHibernate.Session;

namespace SampleArchiteture.Infraestrutura.Tests
{
    internal class NHibernateModule : StartupModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => SQLiteConfiguration.Standard.InMemory().ShowSql()).As<IPersistenceConfigurer>();

            builder.Register(c => new SampleSession(c.Resolve<IPersistenceConfigurer>()).Session).As<ISession>();

            base.Load(builder);
        }
    }
}
