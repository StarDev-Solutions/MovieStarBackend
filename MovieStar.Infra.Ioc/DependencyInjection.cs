using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieStar.Application.Contracts.Services;
using MovieStar.Application.Extensions.Mappings;
using MovieStar.Application.Services;
using MovieStar.Domain.Repositories;
using MovieStar.Infra.Data.Persistence;
using MovieStar.Infra.Data.Repositories;

namespace MovieStar.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMovieStarInfra(this IServiceCollection services, IConfiguration configuration)
        {
            // - Serviços do usuario
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            // - Serviços do filme
            services.AddScoped<IFilmeRepository, FilmeRepository>();
            services.AddScoped<IFilmeService, FilmeService>();

            // - Serviços de serie
            services.AddScoped<ISerieRepository, SerieRepository>();
            services.AddScoped<ISerieService, SerieService>();

            // - Serviços do gênero
            services.AddScoped<IGeneroService, GeneroService>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();

            // - Serviços de avaliacao filme
            services.AddScoped<IAvaliacaoFilmeService, AvaliacaoFilmeService>();
            services.AddScoped<IAvaliacaoFilmeRepository, AvaliacaoFilmeRepository>();

            // - Serviços de avaliacao serie
            services.AddScoped<IAvaliacaoSerieService, AvaliacaoSerieService>();
            services.AddScoped<IAvaliacaoSerieRepository, AvaliacaoSerieRepository>();

            // - Serviços de Episodio
            services.AddScoped<IEpisodioService, EpisodioService>();
            services.AddScoped<IEpisodioRepository, EpisodioRepository>();

            // - Serviços de Temporada
            services.AddScoped<ITemporadaService, TemporadaService>();
            services.AddScoped<ITemporadaRepository, TemporadaRepository>();

            // - Serviço de Personagem
            services.AddScoped<IPersonagemService, PersonagemService>();
            services.AddScoped<IPersonagemRepository, PersonagemRepository>();


            // - Serviço de conexão com o banco de dados
            services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            services.AddAutoMapper(typeof(MappingDTOs));


            return services;

        }
    }
}