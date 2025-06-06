using MovieStar.Domain.Entities;

namespace MovieStar.Domain.Repositories
{
    public interface IAvaliacaoSerieRepository
    {
        Task<AvaliacaoSerie?> GetByIdAsync(Guid id);
        Task<IEnumerable<AvaliacaoSerie>> GetAllBySeriesIdAsync(Guid serieId);
        Task<IEnumerable<AvaliacaoSerie>> GetAllByUserIdAsync(Guid userId);
        Task AddAsync(AvaliacaoSerie avaliacao);
        Task UpdateAsync(AvaliacaoSerie avaliacao);
        Task DeleteAsync(Guid id);
    }
}
