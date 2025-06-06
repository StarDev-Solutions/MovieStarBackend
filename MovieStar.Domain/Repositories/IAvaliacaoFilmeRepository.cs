using MovieStar.Domain.Entities;

namespace MovieStar.Domain.Repositories
{
    public interface IAvaliacaoFilmeRepository
    {
        Task<AvaliacaoFilme?> GetByIdAsync(Guid avaliacaoId);
        Task<IEnumerable<AvaliacaoFilme>> GetAllByMovieIdAsync(Guid movieId);
        Task<IEnumerable<AvaliacaoFilme>> GetAllByUserIdAsync(Guid userId);
        Task AddAsync(AvaliacaoFilme avaliacao);
        Task UpdateAsync(AvaliacaoFilme avaliacao);
        Task DeleteAsync(Guid avaliacaoId);
    }
}