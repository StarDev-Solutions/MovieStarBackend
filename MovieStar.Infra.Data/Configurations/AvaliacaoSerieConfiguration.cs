using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieStar.Domain.Entities;

namespace MovieStar.Infra.Data.Configurations
{
    public class AvaliacaoSerieConfiguration : AvaliacaoConfiguration<AvaliacaoSerie>
    {
        public override void Configure(EntityTypeBuilder<AvaliacaoSerie> builder)
        {
            base.Configure(builder);

            builder.ToTable("AvaliacoesSeries");

            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Serie)
                   .WithMany(s => s.Avaliacoes)
                   .HasForeignKey(a => a.SerieId);

            builder.HasOne(a => a.Usuario)
                   .WithMany(u => u.AvaliacoesSerie)
                   .HasForeignKey(a => a.UsuarioId);
        }
    }
}