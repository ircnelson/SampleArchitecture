using System;
using Autofac;
using SampleArchiteture.Dominio.Services;

namespace SampleArchiteture.Infraestrutura.IoC
{
    public class IoC
    {
        public static IContainer Container { get; private set; }

        public static void Configure(params Module[] modules)
        {
            var builder = new ContainerBuilder();
            
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
