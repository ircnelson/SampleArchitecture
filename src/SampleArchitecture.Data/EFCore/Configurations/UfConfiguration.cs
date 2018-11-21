using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleArchitecture.Core.Entities;

namespace SampleArchitecture.Data.EFCore.Configurations
{
    public class UfConfiguration : IEntityTypeConfiguration<Uf>
    {
        public void Configure(EntityTypeBuilder<Uf> builder)
        {
            builder
                .ToTable("Ufs")
                .HasKey(e => e.Id);
        }
    }
}