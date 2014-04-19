using System.Data.Common;
using Autofac;
using Effort;
using SampleArchiteture.Orm.EntityFramework;

namespace SampleArchiteture.Armazenamento.Tests.Modules
{
    /// <summary>
    /// Módulo de configuração do EntityFramework para o Container de Injeção de Dependência
    /// </summary>
    internal class EntityFrameworkModule : StartupModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => DbConnectionFactory.CreateTransient()).As<DbConnection>();

            base.Load(builder);
        }
    }
}