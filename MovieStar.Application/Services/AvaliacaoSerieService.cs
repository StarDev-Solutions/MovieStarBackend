using AutoMapper;
using MovieStar.Application.Contracts.Services;
using MovieStar.Application.DTOs.Request;
using MovieStar.Application.DTOs.Response;
using MovieStar.Domain.Entities;
using MovieStar.Domain.Repositories;

namespace MovieStar.Application.Services
{
    public class AvaliacaoSerieService : IAvaliacaoSerieService
    {
        private readonly IAvaliacaoSerieRepository _avaliacaoRepository;
        private readonly IMapper _mapper;

        public AvaliacaoSerieService(IAvaliacaoSerieRepository avaliacaoRepository, IMapper mapper)
        {
            _avaliacaoRepository = avaliacaoRepository;
            _mapper = mapper;
        }

        public async Task<AvaliacaoSerieResponse> GetByIdAsync(Guid id)
        {
            var avaliacao = await _avaliacaoRepository.GetByIdAsync(id);
            if (avaliacao == null)
                throw new Exception("Avaliação não encontrada.");

            return _mapper.Map<AvaliacaoSerieResponse>(avaliacao);
        }

        public async Task<IEnumerable<AvaliacaoSerieResponse>> GetBySerieIdAsync(Guid serieId)
        {
            var avaliacoes = await _avaliacaoRepository.GetAllBySeriesIdAsync(serieId);

            if (avaliacoes == null || !avaliacoes.Any())
                return Enumerable.Empty<AvaliacaoSerieResponse>();

            return _mapper.Map<IEnumerable<AvaliacaoSerieResponse>>(avaliacoes);
        }

        public async Task<IEnumerable<AvaliacaoSerieResponse>> GetByUserIdAsync(Guid userId)
        {
            var avaliacoes = await _avaliacaoRepository.GetAllByUserIdAsync(userId);

            if (avaliacoes == null || !avaliacoes.Any())
                return Enumerable.Empty<AvaliacaoSerieResponse>();

            return _mapper.Map<IEnumerable<AvaliacaoSerieResponse>>(avaliacoes);
        }

        public async Task AddAsync(AvaliacaoRequest avaliacao)
        {
            var entidade = _mapper.Map<AvaliacaoSerie>(avaliacao);
            await _avaliacaoRepository.AddAsync(entidade);
        }

        public async Task UpdateAsync(AvaliacaoRequest avaliacao)
        {
            var existente = await _avaliacaoRepository.GetByIdAsync(avaliacao.Id);
            if (existente == null)
                throw new Exception("Avaliação não encontrada.");

            if (avaliacao.Comentario != existente.Comentario)
                existente.AtualizarComentario(avaliacao.Comentario);

            if (avaliacao.Nota != existente.Nota)
                existente.AtualizarNota(avaliacao.Nota);

            existente.AtualizarDataAvaliacao();

            await _avaliacaoRepository.UpdateAsync(existente);
        }

        public async Task DeleteAsync(Guid id)
        {
            var avaliacao = await _avaliacaoRepository.GetByIdAsync(id);
            if (avaliacao == null)
                throw new Exception("Avaliação não encontrada.");

            await _avaliacaoRepository.DeleteAsync(avaliacao.Id);
        }
    }
}
