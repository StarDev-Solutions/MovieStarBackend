using MovieStar.Domain.Entities;

namespace MovieStar.Domain.Repositories
{
    public interface IEpisodioRepository
    {
        Task<Episodio?> GetByIdAsync(Guid id);
        Task<Episodio?> GetByNumberInSeasonAsync(int number, Guid seasonId);
        Task<IEnumerable<Episodio>> GetAllInSeasonAsync(Guid seasonId);
        Task AddAsync(Episodio episodio);
        Task UpdateAsync(Episodio episodio);
        Task DeleteAsync(Guid id);
    }
}
