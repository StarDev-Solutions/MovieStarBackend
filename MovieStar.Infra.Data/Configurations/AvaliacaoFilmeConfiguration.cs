using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieStar.Domain.Entities;

namespace MovieStar.Infra.Data.Configurations
{
    public class AvaliacaoFilmeConfiguration : AvaliacaoConfiguration<AvaliacaoFilme>
    {
        public override void Configure(EntityTypeBuilder<AvaliacaoFilme> builder)
        {
            base.Configure(builder);

            builder.ToTable("AvaliacoesFilmes");

            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Filme)
                   .WithMany(f => f.Avaliacoes)
                   .HasForeignKey(a => a.FilmeId);

            builder.HasOne(a => a.Usuario)
                   .WithMany(u => u.AvaliacoesFilme)
                   .HasForeignKey(a => a.UsuarioId);
        }
    }
}