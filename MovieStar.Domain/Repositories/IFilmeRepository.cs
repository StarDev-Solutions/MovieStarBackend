using MovieStar.Domain.Entities;

namespace MovieStar.Domain.Repositories
{
    public interface IFilmeRepository
    {
        Task<Filme?> GetByIdAsync(Guid id);
        Task<Filme?> GetByNameAsync(string name);
        Task<IEnumerable<Filme>> GetAllAsync();
        Task<IEnumerable<Filme>> GetAllRangeAsync(int skip, int take);
        Task<IEnumerable<Filme>> GetByGenreAsync(string genre);
        Task<IEnumerable<Filme>> GetByRatedAsync(int rated);
        Task<IEnumerable<Filme>> GetByReleaseDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Filme>> GetByRatingRangeAsync(double minRating, double maxRating);
        Task AddAsync(Filme filme);
        Task UpdateAsync(Filme filme);
        Task DeleteAsync(Guid id);
    }
}