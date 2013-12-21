using System;
using System.Data.Entity;
using Autofac;
using SampleArchiteture.Dominio.Repositories;
using SampleArchiteture.Infraestrutura.Data;
using SampleArchiteture.Infraestrutura.EntityFramework.Context;
using SampleArchiteture.Infraestrutura.EntityFramework.Repositories;

namespace SampleArchiteture.Infraestrutura.EntityFramework
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

            builder.RegisterType<SampleContext>().As<DbContext, IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<ClienteRepository>().As<IClienteRepository>().InstancePerDependency();

            base.Load(builder);
        }
    }
}
