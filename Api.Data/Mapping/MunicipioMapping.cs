using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class MunicipioMapping : IEntityTypeConfiguration<MunicipioEntity>
    {
        public void Configure(EntityTypeBuilder<MunicipioEntity> builder)
        {
            builder.ToTable("Municipio");

            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.CodIBGE).IsUnique();
            builder.HasOne(u => u.Uf).WithMany(m => m.Municipios);
        }
    }
}
