﻿using System.Data.Entity;
using Autofac;
using SampleArchiteture.Dominio.Repositories;
using SampleArchiteture.Infraestrutura.Data;
using SampleArchiteture.Orm.EntityFramework.Context;
using SampleArchiteture.Orm.EntityFramework.Repositories;

namespace SampleArchiteture.Orm.EntityFramework
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