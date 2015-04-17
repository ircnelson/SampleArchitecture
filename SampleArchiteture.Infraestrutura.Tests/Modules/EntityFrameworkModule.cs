using System.Data.Common;
using System.Data.Entity;
using Autofac;
using Effort;
using SampleArchiteture.Dominio.Repositories;
using SampleArchiteture.Infraestrutura.Data;
using SampleArchiteture.Infraestrutura.EntityFramework.Context;
using SampleArchiteture.Infraestrutura.EntityFramework.Repositories;

namespace SampleArchiteture.Infraestrutura.Tests.Modules
{
    /// <summary>
    /// Módulo de configuração do EntityFramework para o Container de Injeção de Dependência
    /// </summary>
    internal class EntityFrameworkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => DbConnectionFactory.CreateTransient()).As<DbConnection>();
            builder.RegisterType<SampleContext>().As<DbContext, IUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<,>)).AsSelf().InstancePerDependency();
            builder.RegisterType<UsuarioRepository>().As<IUsuarioRepository>().InstancePerDependency();

            base.Load(builder);
        }

    }
}