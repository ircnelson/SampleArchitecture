using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Effort;
using SampleArchiteture.Infraestrutura.EntityFramework.Context;

namespace SampleArchiteture.Infraestrutura.EntityFramework.Tests
{
    public class TestesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => DbConnectionFactory.CreateTransient()).As<DbConnection>();
        }
    }
}
