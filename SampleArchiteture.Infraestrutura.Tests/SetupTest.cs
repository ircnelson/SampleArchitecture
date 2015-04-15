using Autofac;
using SampleArchiteture.Infraestrutura.Tests.Modules;

namespace SampleArchiteture.Infraestrutura.Tests
{
    public class SetupTest
    {
        public static IContainer Container
        {
            get
            {
                IoC.IoC.Configure(new NHibernateModule());

                return IoC.IoC.Container;
            }
        }
    }
}
