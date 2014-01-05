using System;
using System.Data.Entity;
using Autofac;
using SampleArchiteture.Dominio.Repositories;
using SampleArchiteture.Infraestrutura.Data;
using SampleArchiteture.Infraestrutura.EntityFramework.Context;
using SampleArchiteture.Infraestrutura.EntityFramework.Repositories;

namespace SampleArchiteture.Infraestrutura.EntityFramework
{
    public class StartupModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SampleContext>().As<DbContext, IUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<,>)).AsSelf().InstancePerDependency();
            builder.RegisterType<UsuarioRepository>().As<IUsuarioRepository>().InstancePerDependency();
        }
    }
}
