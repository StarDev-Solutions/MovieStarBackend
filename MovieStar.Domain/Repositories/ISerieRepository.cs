using MovieStar.Domain.Entities;

namespace MovieStar.Domain.Repositories
{
    public interface ISerieRepository
    {
        Task<Serie?> GetByIdAsync(Guid id);
        Task<Serie?> GetByNameAsync(string name);
        Task<IEnumerable<Serie>> GetAllAsync();
        Task<IEnumerable<Serie>> GetAllRangeAsync(int skip, int take);
        Task<IEnumerable<Serie>> GetByGenreAsync(string genre);
        Task<IEnumerable<Serie>> GetByReleaseDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Serie>> GetByRatingRangeAsync(double minRating, double maxRating);
        Task AddAsync(Serie serie);
        Task UpdateAsync(Serie serie);
        Task DeleteAsync(Guid id);
    }
}