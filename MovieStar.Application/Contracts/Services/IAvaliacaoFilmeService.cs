using MovieStar.Application.DTOs.Request;
using MovieStar.Application.DTOs.Response;

namespace MovieStar.Application.Contracts.Services
{
    public interface IAvaliacaoFilmeService
    {
        Task<AvaliacaoFilmeResponse> GetByIdAsync(Guid id);
        Task<IEnumerable<AvaliacaoFilmeResponse>> GetByMovieIdAsync(Guid filmeId);
        Task<IEnumerable<AvaliacaoFilmeResponse>> GetByUserIdAsync(Guid userId);
        Task AddAsync(AvaliacaoRequest avaliacao);
        Task UpdateAsync(AvaliacaoRequest avaliacao);
        Task DeleteAsync(Guid id);
    }
}
