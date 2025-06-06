using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieStar.Application.Contracts.Services;
using MovieStar.Application.Services;
using MovieStar.Domain.Repositories;
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

            // - Serviços de avaliacao filme
            services.AddScoped<IAvaliacaoFilmeService, AvaliacaoFilmeService>();

            // - Serviços de avaliacao serie
            services.AddScoped<IAvaliacaoSerieService, AvaliacaoSerieService>();

            // - Serviços de Episodio
            services.AddScoped<IEpisodioService, EpisodioService>();

            // - Serviços de Temporada
            services.AddScoped<ITemporadaService, TemporadaService>();

            // - Serviço de Personagem
            services.AddScoped<IPersonagemService, PersonagemService>();

            return services;

        }
    }
}