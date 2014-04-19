using NHibernate;

namespace SampleArchiteture.Orm.NHibernate.Repositories
{
    /// <summary>
    /// Classe base para um repositório NHibernate.
    /// </summary>
    public abstract class Repository
    {
        protected readonly ISession Session;

        protected Repository(ISession session)
        {
            Session = session;
        }
    }
}
