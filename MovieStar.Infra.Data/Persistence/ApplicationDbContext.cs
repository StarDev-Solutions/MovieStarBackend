using Microsoft.EntityFrameworkCore;
using MovieStar.Domain.Entities;

namespace MovieStar.Infra.Data.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Temporada> Temporadas { get; set; }
        public DbSet<AvaliacaoFilme> AvaliacaoFilmes { get; set; }
        public DbSet<AvaliacaoSerie> AvaliacaoSeries { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Personagem> Personagens { get; set; }
        public DbSet<Episodio> Episodios { get; set; }
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=MovieStarDb;User Id=sa;Password=StarDev!;TrustServerCertificate=True;");
        }
    }
}