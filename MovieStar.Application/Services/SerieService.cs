using MovieStar.Application.Contracts.Services;
using MovieStar.Application.DTOs.Request;
using MovieStar.Application.DTOs.Response;

namespace MovieStar.Application.Services
{
    public class SerieService : ISerieService
    {
        public Task AddAsync(SerieRequest serie)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SerieResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SerieResponse>> GetAllRangeAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SerieResponse>> GetByGenreAsync(string genre)
        {
            throw new NotImplementedException();
        }

        public Task<SerieResponse> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<SerieResponse> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SerieResponse>> GetByRatingRangeAsync(double minRating, double maxRating)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SerieResponse>> GetByReleaseDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SerieRequest serie)
        {
            throw new NotImplementedException();
        }
    }
}