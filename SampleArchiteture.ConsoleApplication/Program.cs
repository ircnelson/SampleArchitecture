using System;
using System.ComponentModel;
using Autofac;
using SampleArchiteture.Dominio.Entities;
using SampleArchiteture.Dominio.Repositories;
using SampleArchiteture.Infraestrutura.Data;
using SampleArchiteture.Infraestrutura.EntityFramework.Context;
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

                unitOfWork.Commit();
            }
            
        }
    }
}
