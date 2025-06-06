using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieStar.Domain.Entities;

namespace MovieStar.Infra.Data.Configurations
{
    public class SerieConfiguration : IEntityTypeConfiguration<Serie>
    {
        public void Configure(EntityTypeBuilder<Serie> builder)
        {
            builder.ToTable("Series");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Nome).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Descricao).HasMaxLength(1000);
            builder.Property(s => s.Classificacao).HasMaxLength(20);
            builder.Property(s => s.Origem).HasMaxLength(50);
            builder.Property(s => s.FaixaEtaria).IsRequired();
            builder.Property(s => s.Imagem).HasColumnType("varbinary(max)");

            builder.HasMany(s => s.Avaliacoes)
                .WithOne(a => a.Serie)
                .HasForeignKey(a => a.SerieId);

            builder.HasMany(s => s.Temporada)
                .WithOne(t => t.Serie)
                .HasForeignKey(t => t.SerieId);

            builder.HasMany(s => s.Elenco)
                .WithMany()
                .UsingEntity(j => j.ToTable("SerieElencos"));

            builder.HasMany(s => s.Genero)
                    .WithMany()
                    .UsingEntity(j => j.ToTable("SerieGeneros"));
        }
    }

}