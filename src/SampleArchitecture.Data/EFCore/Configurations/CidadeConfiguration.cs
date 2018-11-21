using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleArchitecture.Core.Entities;

namespace SampleArchitecture.Data.EFCore.Configurations
{
    public class CidadeConfiguration : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder
                .ToTable("Cidades")
                .HasKey(e => e.Id);

            builder
                .HasOne(e => e.Uf)
                .WithMany()
                .HasForeignKey(e => e.UfId);
        }
    }
}