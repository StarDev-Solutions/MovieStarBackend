using AutoMapper;
using MovieStar.Application.Contracts.Services;
using MovieStar.Application.DTOs.Request;
using MovieStar.Application.DTOs.Response;
using MovieStar.Domain.Entities;
using MovieStar.Domain.Repositories;

namespace MovieStar.Application.Services
{
    public class TemporadaService : ITemporadaService
    {
        private readonly ITemporadaRepository _temporadaRepository;
        private readonly IMapper _mapper;

        public TemporadaService(ITemporadaRepository temporadaRepository, IMapper mapper)
        {
            _temporadaRepository = temporadaRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(TemporadaRequest temporadaRequest)
        {
            var temporada = _mapper.Map<Temporada>(temporadaRequest);
            await _temporadaRepository.AddAsync(temporada);
        }

        public async Task DeleteAsync(Guid temporadaId)
        {
            var existente = await _temporadaRepository.GetByIdAsync(temporadaId);
            if (existente == null)
                throw new Exception("Temporada não encontrada.");

            await _temporadaRepository.DeleteAsync(temporadaId);
        }

        public async Task<TemporadaResponse> GetByIdAsync(Guid id)
        {
            var temporada = await _temporadaRepository.GetByIdAsync(id);
            if (temporada == null)
                throw new Exception("Temporada não encontrada.");

            return _mapper.Map<TemporadaResponse>(temporada);
        }

        public async Task<TemporadaResponse> GetByNumberSeriesAsync(int number, Guid seriesID)
        {
            var temporada = await _temporadaRepository.GetByNumberSeriesAsync(number, seriesID);
            if (temporada == null)
                throw new Exception("Temporada não encontrada.");

            return _mapper.Map<TemporadaResponse>(temporada);
        }

        public async Task<IEnumerable<TemporadaResponse>> GetBySeriesAsync(Guid seriesID)
        {
            var temporadas = await _temporadaRepository.GetBySeriesAsync(seriesID);
            if (temporadas == null || !temporadas.Any())
                return Enumerable.Empty<TemporadaResponse>();

            return _mapper.Map<IEnumerable<TemporadaResponse>>(temporadas);
        }

        public async Task UpdateAsync(TemporadaRequest temporadaRequest)
        {
            var existente = await _temporadaRepository.GetByIdAsync(temporadaRequest.Id);
            if (existente == null)
                throw new Exception("Temporada não encontrada.");
            //validações e updates

            await _temporadaRepository.UpdateAsync(existente);
        }
    }
}
