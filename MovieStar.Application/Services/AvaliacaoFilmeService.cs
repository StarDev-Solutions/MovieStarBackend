using AutoMapper;
using MovieStar.Application.Contracts.Services;
using MovieStar.Application.DTOs.Request;
using MovieStar.Application.DTOs.Response;
using MovieStar.Domain.Entities;
using MovieStar.Domain.Repositories;

namespace MovieStar.Application.Services
{
    public class AvaliacaoFilmeService : IAvaliacaoFilmeService
    {
        private readonly IAvaliacaoFilmeRepository _avaliacaoRepository;
        private readonly IMapper _mapper;

        public AvaliacaoFilmeService(IAvaliacaoFilmeRepository avaliacaoRepository, IMapper mapper)
        {
            _avaliacaoRepository = avaliacaoRepository;
            _mapper = mapper;
        }

        public async Task<AvaliacaoFilmeResponse> GetByIdAsync(Guid id)
        {
            var avaliacao = await _avaliacaoRepository.GetByIdAsync(id);
            if (avaliacao == null)
                throw new Exception("Avaliação não encontrada.");

            return _mapper.Map<AvaliacaoFilmeResponse>(avaliacao);
        }

        public async Task<IEnumerable<AvaliacaoFilmeResponse>> GetByMovieIdAsync(Guid filmeId)
        {
            var avaliacoes = await _avaliacaoRepository.GetAllByMovieIdAsync(filmeId);

            if (avaliacoes == null || !avaliacoes.Any())
                return Enumerable.Empty<AvaliacaoFilmeResponse>();

            return _mapper.Map<IEnumerable<AvaliacaoFilmeResponse>>(avaliacoes);
        }

        public async Task<IEnumerable<AvaliacaoFilmeResponse>> GetByUserIdAsync(Guid userId)
        {
            var avaliacoes = await _avaliacaoRepository.GetAllByUserIdAsync(userId);

            if (avaliacoes == null || !avaliacoes.Any())
                return Enumerable.Empty<AvaliacaoFilmeResponse>();

            return _mapper.Map<IEnumerable<AvaliacaoFilmeResponse>>(avaliacoes);
        }

        public async Task AddAsync(AvaliacaoRequest avaliacao)
        {
            var entidade = _mapper.Map<AvaliacaoFilme>(avaliacao);
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