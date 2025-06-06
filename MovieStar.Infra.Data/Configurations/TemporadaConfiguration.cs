using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStar.Domain.Entities;

namespace MovieStar.Infra.Data.Configurations
{
    public class TemporadaConfiguration : IEntityTypeConfiguration<Temporada>
    {
        public void Configure(EntityTypeBuilder<Temporada> builder)
        {
            builder.ToTable("Temporadas");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Numero).IsRequired();
            builder.Property(t => t.DataLancamento).IsRequired();

            builder.HasMany(t => t.Episodio)
                .WithOne(e => e.Temporada)
                .HasForeignKey(e => e.TemporadaId);
        }
    }
}