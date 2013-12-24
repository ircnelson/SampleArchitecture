using System;
using Autofac;
using SampleArchiteture.Dominio.Repositories;
using SampleArchiteture.Infraestrutura.Data;
using SampleArchiteture.Infraestrutura.IoC;

namespace SampleArchiteture.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            IoC.Configure();
            
            using (var scope = IoC.Container)
            {
                var unitOfWork = scope.Resolve<IUnitOfWork>();
                var usuarioRepository = scope.Resolve<IUsuarioRepository>();

                var usuario = usuarioRepository.Get(1);

                Console.WriteLine(usuario);

                unitOfWork.Commit();
            }
            
        }
    }
}
