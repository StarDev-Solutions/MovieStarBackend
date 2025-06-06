using MovieStar.Application.DTOs.Request;
using MovieStar.Application.DTOs.Response;

namespace MovieStar.Application.Contracts.Services
{
    public interface IAvaliacaoSerieService
    {
        Task<AvaliacaoSerieResponse> GetByIdAsync(Guid id);
        Task<IEnumerable<AvaliacaoSerieResponse>> GetBySerieIdAsync(Guid serieId);
        Task<IEnumerable<AvaliacaoSerieResponse>> GetByUserIdAsync(Guid userId);
        Task AddAsync(AvaliacaoRequest avaliacao);
        Task UpdateAsync(AvaliacaoRequest avaliacao);
        Task DeleteAsync(Guid id);
    }
}
