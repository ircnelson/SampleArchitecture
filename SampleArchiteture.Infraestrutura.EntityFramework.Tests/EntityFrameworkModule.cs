using System.Data.Common;
using Autofac;
using Effort;
using SampleArchiteture.Infraestrutura.EntityFramework;

namespace SampleArchiteture.Infraestrutura.Tests
{
    internal class EntityFrameworkModule : StartupModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => DbConnectionFactory.CreateTransient()).As<DbConnection>();

            base.Load(builder);
        }
    }
}
