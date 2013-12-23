using System.Data.Common;
using Autofac;
using Effort;

namespace SampleArchiteture.Infraestrutura.Tests
{
    /// <summary>
    /// Módulo de configuração do EntityFramework para o Container de Injeção de Dependência
    /// </summary>
    internal class EntityFrameworkModule : EntityFramework.StartupModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => DbConnectionFactory.CreateTransient()).As<DbConnection>();

            base.Load(builder);
        }
    }
}