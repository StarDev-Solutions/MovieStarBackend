using AutoMapper;
using MovieStar.Application.DTOs.Request;
using MovieStar.Application.DTOs.Response;
using MovieStar.Domain.Entities;

namespace MovieStar.Application.Extensions.Mappings
{
    public class MappingDTOs : Profile
    {
        public MappingDTOs()
        {

            // - Mapeamento Genero
            CreateMap<GeneroRequest, Genero>();
            CreateMap<Genero, GeneroResponse>();

            // - Mapeamento Personagem(Elenco)
            CreateMap<PersonagemRequest, Personagem>();
            CreateMap<Personagem, PersonagemResponse>();

            // - Mapeamento Avaliacao
            CreateMap<AvaliacaoRequest, AvaliacaoFilme>();
            CreateMap<AvaliacaoRequest, AvaliacaoSerie>();
            CreateMap<AvaliacaoFilme, AvaliacaoFilmeResponse>();
            CreateMap<AvaliacaoSerie, AvaliacaoSerieResponse>();

            // - Mapeamento Temporada
            CreateMap<TemporadaRequest, Temporada>();
            CreateMap<Temporada, TemporadaResponse>();

            // - Mapeamento Episodio
            CreateMap<EpisodioRequest, Episodio>();
            CreateMap<Episodio, EpisodioResponse>();

            // - Mapeamento Filme
            CreateMap<FilmeRequest, Filme>()
                .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => src.Genero))
                .ForMember(dest => dest.Elenco, opt => opt.MapFrom(src => src.Elenco))
                .ForMember(dest => dest.Avaliacoes, opt => opt.MapFrom(src => src.Avaliacoes ?? new List<AvaliacaoRequest>()))
                .ForMember(dest => dest.Classificacao, opt => opt.MapFrom(src => src.Classificacao ?? 0));

            CreateMap<Filme, FilmeResponse>()
                .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => src.Genero))
                .ForMember(dest => dest.Elenco, opt => opt.MapFrom(src => src.Elenco))
                .ForMember(dest => dest.Avaliacoes, opt => opt.MapFrom(src => src.Avaliacoes));

            // - Mapeamento Serie
            CreateMap<SerieRequest, Serie>()
                .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => src.Genero))
                .ForMember(dest => dest.Elenco, opt => opt.MapFrom(src => src.Elenco))
                .ForMember(dest => dest.Avaliacoes, opt => opt.MapFrom(src => src.Avaliacoes ?? new List<AvaliacaoRequest>()))
                .ForMember(dest => dest.Temporada, opt => opt.MapFrom(src => src.Temporadas))
                .ForMember(dest => dest.Classificacao, opt => opt.MapFrom(src => src.Classificacao ?? 0));

            CreateMap<Serie, SerieResponse>()
                .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => src.Genero))
                .ForMember(dest => dest.Elenco, opt => opt.MapFrom(src => src.Elenco))
                .ForMember(dest => dest.Avaliacoes, opt => opt.MapFrom(src => src.Avaliacoes))
                .ForMember(dest => dest.Temporadas, opt => opt.MapFrom(src => src.Temporada));
        }
    }
}
