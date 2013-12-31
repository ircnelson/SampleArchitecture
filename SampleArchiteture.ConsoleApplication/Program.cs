using System;
using Autofac;
using SampleArchiteture.Dominio.Repositories;
using SampleArchiteture.Infraestrutura.Data;
using SampleArchiteture.Infraestrutura.IoC;
using SampleArchiteture.Infraestrutura.NHibernate;

namespace SampleArchiteture.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            IoC.Configure(new StartupModule());
            
            using (var scope = IoC.Container)
            {
                var unitOfWork = scope.Resolve<IUnitOfWork>();
                var usuarioRepository = scope.Resolve<IUsuarioRepository>();

                Console.WriteLine(usuarioRepository);
            }
        }
    }
}
