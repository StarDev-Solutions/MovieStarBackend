using MovieStar.Domain.Entities;

namespace MovieStar.Domain.Repositories
{
    public interface ITemporadaRepository
    {
        Task<Temporada?> GetByIdAsync(Guid id);
        Task<IEnumerable<Temporada>> GetBySeriesAsync(Guid seriesID);
        Task<Temporada?> GetByNumberSeriesAsync(int number, Guid seriesID);
        Task AddAsync(Temporada temporada);
        Task UpdateAsync(Temporada temporada);
        Task DeleteAsync(Guid id);
    }
}