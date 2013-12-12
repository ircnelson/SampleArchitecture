using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace SampleArchiteture.ConsoleApplication
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            
            Container = builder.Build();

            using (var scope = Container.BeginLifetimeScope())
            {
                
            }
        }
    }
}
