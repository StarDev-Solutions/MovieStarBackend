using MovieStar.Application.DTOs.Request;
using MovieStar.Application.DTOs.Response;

namespace MovieStar.Application.Contracts.Services
{
    public interface ISerieService
    {
        Task<SerieResponse> GetByIdAsync(Guid id);
        Task<SerieResponse> GetByNameAsync(string name);
        Task<IEnumerable<SerieResponse>> GetAllAsync();
        Task<IEnumerable<SerieResponse>> GetAllRangeAsync(int skip, int take);
        Task<IEnumerable<SerieResponse>> GetByGenreAsync(string genre);
        Task<IEnumerable<SerieResponse>> GetByReleaseDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<SerieResponse>> GetByRatingRangeAsync(double minRating, double maxRating);
        Task AddAsync(SerieRequest serie);
        Task UpdateAsync(SerieRequest serie);
        Task DeleteAsync(Guid id);
    }
}