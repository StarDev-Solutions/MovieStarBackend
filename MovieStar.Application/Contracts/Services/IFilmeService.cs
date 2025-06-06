using MovieStar.Application.DTOs.Request;
using MovieStar.Application.DTOs.Response;
using MovieStar.Domain.Entities;

namespace MovieStar.Application.Contracts.Services
{
    public interface IFilmeService
    {
        Task<FilmeResponse> GetByIdAsync(Guid id);
        Task<FilmeResponse> GetByNameAsync(string name);
        Task<IEnumerable<FilmeResponse>> GetAllAsync();
        Task<IEnumerable<FilmeResponse>> GetAllRangeAsync(int skip, int take);
        Task<IEnumerable<FilmeResponse>> GetByGenreAsync(string genre);
        Task<IEnumerable<FilmeResponse>> GetByRatedAsync(int rated);
        Task<IEnumerable<FilmeResponse>> GetByReleaseDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<FilmeResponse>> GetByRatingRangeAsync(double minRating, double maxRating);
        Task AddAsync(FilmeRequest filme);
        Task UpdateAsync(FilmeRequest filme);
        Task DeleteAsync(Guid id);
    }
}