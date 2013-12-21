using System.Data.Common;
using Autofac;
using Effort;

namespace SampleArchiteture.Infraestrutura.EntityFramework.Tests
{
    public class TestesModule : StartupModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => DbConnectionFactory.CreateTransient()).As<DbConnection>();

            base.Load(builder);
        }
    }
}
