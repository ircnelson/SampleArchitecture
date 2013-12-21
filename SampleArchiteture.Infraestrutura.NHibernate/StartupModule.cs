using System;
using Autofac;
using SampleArchiteture.Dominio.Repositories;
using SampleArchiteture.Infraestrutura.Data;
using SampleArchiteture.Infraestrutura.NHibernate.Repositories;
using SampleArchiteture.Infraestrutura.NHibernate.Session;

namespace SampleArchiteture.Infraestrutura.NHibernate
{
    public class StartupModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var typeofRepository = typeof(Repository<,>);
            builder.RegisterAssemblyTypes(typeofRepository.Assembly)
                .Where(t => typeofRepository.IsAssignableFrom(t) && t.Name.EndsWith("Repository", StringComparison.Ordinal))
                .AsSelf()
                .InstancePerDependency();

            builder.RegisterType<SampleSession>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<ClienteRepository>().As<IClienteRepository>().InstancePerDependency();

            base.Load(builder);
        }
    }
}
