using System;
using System.Data.Entity;
using Autofac;
using SampleArchiteture.Dominio.Repositories;
using SampleArchiteture.Dominio.Services;
using SampleArchiteture.Infraestrutura.Data;
using SampleArchiteture.Infraestrutura.EntityFramework.Context;
using SampleArchiteture.Infraestrutura.EntityFramework.Repositories;

namespace SampleArchiteture.Infraestrutura.IoC
{
    public class IoC
    {
        public static IContainer Container { get; private set; }

        public static void Configure(params Module[] modules)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SampleContext>().As<DbContext, IUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<ClienteRepository>().As<IClienteRepository>().InstancePerDependency();

            var typeofServicebase = typeof(IServiceBase);
            builder.RegisterAssemblyTypes(typeofServicebase.Assembly)
                .Where(t => typeofServicebase.IsAssignableFrom(t) && t.Name.EndsWith("Service", StringComparison.Ordinal))
                .AsSelf()
                .InstancePerDependency();

            foreach (var module in modules)
                builder.RegisterModule(module);

            Container = builder.Build();
        }
    }
}
