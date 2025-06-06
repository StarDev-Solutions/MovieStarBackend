using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStar.Domain.Entities;

namespace MovieStar.Infra.Data.Configurations
{
    public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.ToTable("Generos");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Nome).IsRequired().HasMaxLength(50);
        }
    }
}