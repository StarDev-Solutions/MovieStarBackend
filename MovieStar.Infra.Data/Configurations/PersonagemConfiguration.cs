using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieStar.Domain.Entities;

namespace MovieStar.Infra.Data.Configurations
{
    public class PersonagemConfiguration : IEntityTypeConfiguration<Personagem>
    {
        public void Configure(EntityTypeBuilder<Personagem> builder)
        {
            builder.ToTable("Personagens");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.NomePersonagem).IsRequired().HasMaxLength(100);
            builder.Property(p => p.NomeAtor).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Imagem).HasColumnType("varbinary(max)");
        }
    }
}