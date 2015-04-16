using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using SampleArchiteture.Infraestrutura.Data;

namespace SampleArchiteture.Infraestrutura.NHibernate.Session
{
    public class SampleSession : IUnitOfWork
    {
        private ISession Session { get; set; }

        public SampleSession(ISessionFactory sessionFactory, Configuration configuration)
        {
            Session = sessionFactory.OpenSession();
            Session.FlushMode = FlushMode.Auto;

            Session.Transaction.Begin();

            new SchemaExport(configuration).Execute(true, true, false, Session.Connection, null);
        }

        public void Dispose()
        {
            Session.Close();
            Session = null;
        }

        public void Commit()
        {
            if (Session.Transaction.IsActive)
                Session.Transaction.Commit();
        }
    }

    //public class SampleSession : IUnitOfWork
    //{
    //    private ISessionFactory _sessionFactory;
    //    private Configuration _configuration;

    //    public ISession Session { get; private set; }

    //    public SampleSession(IPersistenceConfigurer configurer)
    //    {
    //        _sessionFactory = Fluently.Configure()
    //                .Database(configurer)
    //                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UsuarioMap>())
    //                .ExposeConfiguration(cfg => _configuration = cfg)
    //                .BuildSessionFactory();

    //        Session = _sessionFactory.OpenSession();
    //        Session.FlushMode = FlushMode.Auto;

    //        new SchemaExport(_configuration).Execute(true, true, false, Session.Connection, null);

    //        Session.Transaction.Begin(IsolationLevel.ReadCommitted);
    //    }

    //    public void Commit()
    //    {
    //        if (Session.Transaction.IsActive)
    //            Session.Transaction.Commit();
    //    }

    //    public void Dispose()
    //    {
    //        Session.Close();
    //    }
    //}
}
