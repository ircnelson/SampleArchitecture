using FluentMigrator.Runner;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AssemblyScanDataLayer = SampleArchitecture.Data.AssemblyScan;

namespace SampleArchitecture.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            var configuration = host.Services.GetService<IConfiguration>();

            if (configuration.GetValue<bool>("RUN_MIGRATION_ON_STARTUP"))
            {
                ApplyMigrations(configuration);
            }

            host.Run();
        }
        
        private static void ApplyMigrations(IConfiguration configuration)
        {
            var services = new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .UseSqlite(configuration)
                    .ScanIn(typeof(AssemblyScanDataLayer).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
            
            using (var scope = services.CreateScope())
            {
                var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
                runner.MigrateUp();
            }
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }

    public static class FluentMigratorExtensions
    {
        public static IMigrationRunnerBuilder UseSqlServer(
            this IMigrationRunnerBuilder builder, 
            IConfiguration configuration)
        {
            builder
                .AddSqlServer()
                .WithGlobalConnectionString(configuration.GetConnectionString("ExampleSqlServer"));

            return builder;
        }
        
        public static IMigrationRunnerBuilder UseSqlite(
            this IMigrationRunnerBuilder builder, 
            IConfiguration configuration)
        {
            builder
                .AddSQLite()
                .WithGlobalConnectionString(configuration.GetConnectionString("ExampleSqlite"));

            return builder;
        }
    }
}