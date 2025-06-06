using MovieStar.Application.DTOs.Request;
using MovieStar.Application.DTOs.Response;

namespace MovieStar.Application.Contracts.Services
{
    public interface ITemporadaService
    {
        Task<TemporadaResponse> GetByIdAsync(Guid id);
        Task<IEnumerable<TemporadaResponse>> GetBySeriesAsync(Guid seriesID);
        Task<TemporadaResponse> GetByNumberSeriesAsync(int number, Guid seriesID);
        Task AddAsync(TemporadaRequest temporada);
        Task UpdateAsync(TemporadaRequest temporada);
        Task DeleteAsync(Guid temporadaId);
    }
}