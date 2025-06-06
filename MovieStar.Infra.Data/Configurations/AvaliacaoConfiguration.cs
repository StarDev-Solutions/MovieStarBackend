using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStar.Domain.Entities;

namespace MovieStar.Infra.Data.Configurations
{
    public abstract class AvaliacaoConfiguration<T> : IEntityTypeConfiguration<T> where T : Avaliacao
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(a => a.Comentario)
                   .HasMaxLength(1000);

            builder.Property(a => a.Nota)
                   .IsRequired();

            builder.Property(a => a.DataAvaliacao)
                   .IsRequired();

            builder.Property(a => a.UsuarioId)
                   .IsRequired();
        }
    }
}