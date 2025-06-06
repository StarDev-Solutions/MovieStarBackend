using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStar.Domain.Entities;

namespace MovieStar.Infra.Data.Configurations
{
    public class FilmeConfiguration : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("Filmes");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Nome).IsRequired().HasMaxLength(100);
            builder.Property(f => f.Descricao).HasMaxLength(1000);
            builder.Property(f => f.Duracao).IsRequired();
            builder.Property(f => f.Origem).HasMaxLength(50);
            builder.Property(f => f.DataLancamento).IsRequired();
            builder.Property(f => f.FaixaEtaria).IsRequired();
            builder.Property(f => f.Imagem).HasColumnType("varbinary(max)");

            builder.HasMany(f => f.Genero)
                .WithMany()
                .UsingEntity(j => j.ToTable("FilmeGeneros"));

            builder.HasMany(f => f.Elenco)
                .WithMany()
                .UsingEntity(j => j.ToTable("FilmeElencos"));

            builder.HasMany(f => f.Avaliacoes)
                .WithOne(a => a.Filme)
                .HasForeignKey(a => a.FilmeId);

        }
    }
}