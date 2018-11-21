using Microsoft.EntityFrameworkCore;
using SampleArchitecture.Core.Entities;

namespace SampleArchitecture.Data.EFCore
{
    public class ExampleContext : DbContext
    {
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        
        public ExampleContext(DbContextOptions<ExampleContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations<ExampleContext>();
        }
    }
}