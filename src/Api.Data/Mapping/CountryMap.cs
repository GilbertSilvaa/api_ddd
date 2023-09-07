using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class CountryMap : IEntityTypeConfiguration<CountryEntity>
    {
        public void Configure(EntityTypeBuilder<CountryEntity> builder)
        {
            builder.ToTable("Country");
            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.CodIBGE).IsUnique();

            builder.HasOne(u => u.Uf).WithMany(c => c.Countries);
        }
    }
}
