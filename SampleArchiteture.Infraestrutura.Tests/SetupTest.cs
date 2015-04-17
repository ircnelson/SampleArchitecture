using System;
using System.Linq;
using Autofac;
using PJMT.Framework.DependencyInjection.Autofac;
using PJMT.Framework.DependencyInjection.Interfaces;
using SampleArchiteture.Dominio.Services;
using SampleArchiteture.Infraestrutura.Tests.Modules;

namespace SampleArchiteture.Infraestrutura.Tests
{
    public class SetupTest
    {
        public static IServiceProvider Container
        {
            get
            {
                var builder = new ContainerBuilder();

                var typeofServicebase = typeof(IServiceBase);
                builder.RegisterAssemblyTypes(typeofServicebase.Assembly)
                    .Where(t => typeofServicebase.IsAssignableFrom(t) && t.Name.EndsWith("Service", StringComparison.Ordinal))
                    .AsSelf()
                    .InstancePerDependency();

                builder.RegisterModule(new EntityFrameworkModule());

                builder.Populate(Enumerable.Empty<ServiceDescriptor>());

                IContainer container = builder.Build();

                return container.Resolve<IServiceProvider>();
            }
        }
    }
}
