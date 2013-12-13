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

        public static void Configure(Module module = null)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SampleContext>().As<DbContext, IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<ClienteService>().AsSelf().InstancePerDependency();
            builder.RegisterType<ClienteRepository>().As<IClienteRepository>().InstancePerDependency();

            if (module != null)
                builder.RegisterModule(module);

            Container = builder.Build();
        }
    }
}
