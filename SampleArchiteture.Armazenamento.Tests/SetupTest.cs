﻿using Autofac;
using SampleArchiteture.Armazenamento.Tests.Modules;

namespace SampleArchiteture.Armazenamento.Tests
{
    public class SetupTest
    {
        public static IContainer Container
        {
            get
            {
                Infraestrutura.IoC.IoC.Configure(new EntityFrameworkModule());

                return Infraestrutura.IoC.IoC.Container;
            }
        }
    }
}