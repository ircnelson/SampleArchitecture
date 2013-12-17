using System.Data.Common;
using Autofac;
using Effort;

namespace SampleArchiteture.Infraestrutura.EntityFramework.Tests
{
    public class TestesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => DbConnectionFactory.CreateTransient()).As<DbConnection>();
        }
    }
}
