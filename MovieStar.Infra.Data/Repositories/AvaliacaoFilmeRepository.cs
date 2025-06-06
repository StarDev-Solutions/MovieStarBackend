using Microsoft.EntityFrameworkCore;
using MovieStar.Domain.Entities;
using MovieStar.Domain.Repositories;
using MovieStar.Infra.Data.Persistence;

namespace MovieStar.Infra.Data.Repositories
{
    public class AvaliacaoFilmeRepository : IAvaliacaoFilmeRepository
    {
        private readonly ApplicationDbContext _context;

        public AvaliacaoFilmeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AvaliacaoFilme?> GetByIdAsync(Guid id)
        {
            return await _context.AvaliacaoFilmes.
                AsNoTracking().
                FirstOrDefaultAsync(i => i.Id == id).
                ConfigureAwait(false);
        }

        public async Task<IEnumerable<AvaliacaoFilme>> GetAllByMovieIdAsync(Guid movieId)
        {
            return await _context.
                AvaliacaoFilmes.
                Where(i => i.FilmeId == movieId).
                ToListAsync().
                ConfigureAwait(false);
        }

        public async Task<IEnumerable<AvaliacaoFilme>> GetAllByUserIdAsync(Guid userId)
        {
            return await _context.
                AvaliacaoFilmes.
                Where(i => i.UsuarioId == userId).
                ToListAsync().
                ConfigureAwait(false);
        }

        public async Task AddAsync(AvaliacaoFilme avaliacao)
        {
            _context.Add(avaliacao);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(AvaliacaoFilme avaliacao)
        {
            _context.Update(avaliacao);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(Guid id)
        {
            var avaliacao = await _context.AvaliacaoFilmes.FindAsync(id);
            if (avaliacao != null)
            {
                _context.AvaliacaoFilmes.Remove(avaliacao);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
