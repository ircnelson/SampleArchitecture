using System.Data.Entity;

namespace SampleArchiteture.Orm.EntityFramework.Repositories
{
    /// <summary>
    /// Classe base para um repositório EntityFramework.
    /// </summary>
    public abstract class Repository
    {
        protected readonly DbContext Context;

        protected Repository(DbContext context)
        {
            Context = context;
        }
    }
}
