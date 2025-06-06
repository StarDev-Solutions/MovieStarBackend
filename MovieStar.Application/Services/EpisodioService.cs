using AutoMapper;
using MovieStar.Application.Contracts.Services;
using MovieStar.Application.DTOs.Request;
using MovieStar.Application.DTOs.Response;
using MovieStar.Domain.Entities;
using MovieStar.Domain.Repositories;

namespace MovieStar.Application.Services
{
    public class EpisodioService : IEpisodioService
    {
        private readonly IEpisodioRepository _episodioRepository;
        private readonly IMapper _mapper;

        public EpisodioService(IEpisodioRepository episodioRepository, IMapper mapper)
        {
            _episodioRepository = episodioRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(EpisodioRequest episodioRequest)
        {
            var episodio = _mapper.Map<Episodio>(episodioRequest);
            await _episodioRepository.AddAsync(episodio);
        }

        public async Task DeleteAsync(Guid id)
        {
            var existente = await _episodioRepository.GetByIdAsync(id);
            if (existente == null)
                throw new Exception("Episódio não encontrado.");

            await _episodioRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EpisodioResponse>> GetAllInSeasonAsync(Guid seasonId)
        {
            var episodios = await _episodioRepository.GetAllInSeasonAsync(seasonId);
            if (episodios == null || !episodios.Any())
                return Enumerable.Empty<EpisodioResponse>();

            return _mapper.Map<IEnumerable<EpisodioResponse>>(episodios);
        }

        public async Task<EpisodioResponse> GetByIdAsync(Guid id)
        {
            var episodio = await _episodioRepository.GetByIdAsync(id);
            if (episodio == null)
                throw new Exception("Episódio não encontrado.");

            return _mapper.Map<EpisodioResponse>(episodio);
        }

        public async Task<EpisodioResponse> GetByNumberInSeasonAsync(int number, Guid seasonId)
        {
            var episodio = await _episodioRepository.GetByNumberInSeasonAsync(number, seasonId);
            if (episodio == null)
                throw new Exception("Episódio não encontrado.");

            return _mapper.Map<EpisodioResponse>(episodio);
        }

        public async Task UpdateAsync(EpisodioRequest episodio)
        {
            var existente = await _episodioRepository.GetByIdAsync(episodio.Id);
            if (existente == null)
                throw new Exception("Episódio não encontrado.");

            if (!existente.Nome.Equals(episodio.Nome))
            {
                existente.AlterarNome(episodio.Nome);
            }
            if(!existente.Descricao.Equals(episodio.Descricao))
            {
                existente.AlterarDescricao(episodio.Descricao);
            }
            if(existente.Duracao != episodio.Duracao)
            {
                existente.AlterarDuracao(episodio.Duracao);
            }
            if(existente.Imagem != episodio.Imagem)
            {
                existente.AlterarImagem(episodio.Imagem);
            }
            await _episodioRepository.UpdateAsync(existente);
        }
    }
}
