using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class CepMapping : IEntityTypeConfiguration<CepEntity>
    {
        public void Configure(EntityTypeBuilder<CepEntity> builder)
        {
            builder.ToTable("Cep");

            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Cep).IsUnique();
            builder.HasOne(m => m.Municipio).WithMany(c => c.Ceps);
        }
    }
}
