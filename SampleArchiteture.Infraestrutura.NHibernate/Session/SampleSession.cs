using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Infraestrutura.Data;

namespace SampleArchiteture.Infraestrutura.NHibernate.Session
{
    public class SampleSession : IUnitOfWork
    {
        private ISessionFactory _sessionFactory;
        private Configuration _configuration;

        public ISession Session { get; private set; }

        public SampleSession(IPersistenceConfigurer configurer)
        {
            _sessionFactory = Fluently.Configure()
                    .Database(configurer)
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Cliente>())
                    .ExposeConfiguration(cfg => _configuration = cfg)
                    .BuildSessionFactory();

            Session = _sessionFactory.OpenSession();
            Session.Transaction.Begin();
        }

        public void Dispose()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Dispose();
            }

            Session = null;
            _sessionFactory = null;
            _sessionFactory = null;
            _configuration = null;
        }

        public void Commit()
        {
            Session.Transaction.Commit();
        }
    }
}
