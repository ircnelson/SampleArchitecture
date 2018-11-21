using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleArchitecture.Core.Entities;

namespace SampleArchitecture.Data.EFCore.Configurations
{
    public class BancoConfiguration : IEntityTypeConfiguration<Banco>
    {
        public void Configure(EntityTypeBuilder<Banco> builder)
        {
            builder
                .ToTable("Bancos")
                .HasKey(e => e.Id);

            builder.Property(e => e.Codigo)
                .IsRequired();

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(255);
            
            builder.Property(e => e.NomeCurto)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}