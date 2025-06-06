using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieStar.Domain.Entities;

namespace MovieStar.Infra.Data.Configurations
{
    public class EpisodioConfiguration : IEntityTypeConfiguration<Episodio>
    {
        public void Configure(EntityTypeBuilder<Episodio> builder)
        {
            builder.ToTable("Episodios");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Numero).IsRequired();
            builder.Property(e => e.Nome).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Descricao).HasMaxLength(1000);
            builder.Property(e => e.Duracao).IsRequired();
            builder.Property(e => e.Imagem).HasColumnType("varbinary(max)");
        }
    }
}