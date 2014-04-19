﻿using Autofac;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using SampleArchiteture.Orm.NHibernate;

namespace SampleArchiteture.Armazenamento.Tests.Modules
{
    /// <summary>
    /// Módulo de configuração do NHibernate para o Container de Injeção de Dependência
    /// </summary>
    internal class NHibernateModule : StartupModule
    {
        public NHibernateModule()
        {
            PersistenceConfigurer = SQLiteConfiguration.Standard.InMemory().ShowSql();
            OnSessionActivating = a => new SchemaExport(a.Context.Resolve<Configuration>()).Execute(true, true, false, a.Instance.Connection, null);
        }
    }
}
