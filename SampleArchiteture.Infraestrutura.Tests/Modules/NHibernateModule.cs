using System;
using Autofac;
using Autofac.Core;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using SampleArchiteture.Dominio.Repositories;
using SampleArchiteture.Infraestrutura.Data;
using SampleArchiteture.Infraestrutura.NHibernate.Mapping;
using SampleArchiteture.Infraestrutura.NHibernate.Repositories;
using SampleArchiteture.Infraestrutura.NHibernate.Session;

namespace SampleArchiteture.Infraestrutura.Tests.Modules
{
    /// <summary>
    /// Módulo de configuração do NHibernate para o Container de Injeção de Dependência
    /// </summary>
    internal class NHibernateModule : Module
    {
        protected Configuration Configuration { get; set; }
        protected IPersistenceConfigurer PersistenceConfigurer { get; set; }
        protected Action<IActivatingEventArgs<ISession>> OnSessionActivating { get; set; }

        public NHibernateModule()
        {
            PersistenceConfigurer = SQLiteConfiguration.Standard.InMemory().ShowSql();
            OnSessionActivating = a => new SchemaExport(a.Context.Resolve<Configuration>()).Execute(true, true, false, a.Instance.Connection, null);
        }

        protected override void Load(ContainerBuilder builder)
        {
            var sessionFactory = Fluently.Configure()
                .Database(PersistenceConfigurer)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UsuarioMap>())
                .ExposeConfiguration(cfg => Configuration = cfg)
                .BuildSessionFactory();

            builder.RegisterInstance(Configuration).As<Configuration>().SingleInstance();
            builder.RegisterInstance(sessionFactory).As<ISessionFactory>().SingleInstance();
            builder.Register(c => c.Resolve<ISessionFactory>().OpenSession()).As<ISession>().OnActivating(OnSessionActivating).InstancePerLifetimeScope();
            builder.Register(c => new SampleSession(c.Resolve<ISessionFactory>(), c.Resolve<Configuration>())).As<IUnitOfWork>();

            builder.RegisterGeneric(typeof(Repository<,>)).AsSelf().InstancePerDependency();
            builder.RegisterType<UsuarioRepository>().As<IUsuarioRepository>().InstancePerDependency();
        }
    }
}
