using System.Data.Common;
using Autofac;

namespace SampleArchiteture.Infraestrutura.Tests.Modules
{
    /// <summary>
    /// Módulo de configuração do EntityFramework para o Container de Injeção de Dependência
    /// </summary>
    internal class EntityFrameworkModule : EntityFramework.StartupModule
    {
    }
}