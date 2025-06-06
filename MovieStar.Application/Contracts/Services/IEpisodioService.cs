using MovieStar.Application.DTOs.Request;
using MovieStar.Application.DTOs.Response;

namespace MovieStar.Application.Contracts.Services
{
    public interface IEpisodioService
    {
        Task<EpisodioResponse> GetByIdAsync(Guid id);
        Task<EpisodioResponse> GetByNumberInSeasonAsync(int number, Guid seasonId);
        Task<IEnumerable<EpisodioResponse>> GetAllInSeasonAsync(Guid seasonId);
        Task AddAsync(EpisodioRequest episodio);
        Task UpdateAsync(EpisodioRequest episodio);
        Task DeleteAsync(Guid id);
    }
}