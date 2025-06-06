using Microsoft.EntityFrameworkCore;
using MovieStar.Domain.Entities;
using MovieStar.Domain.Repositories;
using MovieStar.Infra.Data.Persistence;

namespace MovieStar.Infra.Data.Repositories
{
    public class AvaliacaoSerieRepository : IAvaliacaoSerieRepository
    {
        private readonly ApplicationDbContext _context;

        public AvaliacaoSerieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AvaliacaoSerie?> GetByIdAsync(Guid id)
        {
            return await _context.AvaliacaoSeries.
                AsNoTracking().
                FirstOrDefaultAsync(i => i.Id == id).
                ConfigureAwait(false);
        }

        public async Task<IEnumerable<AvaliacaoSerie>> GetAllBySeriesIdAsync(Guid seriesId)
        {
            return await _context.
                AvaliacaoSeries.
                Where(i => i.SerieId == seriesId).
                ToListAsync().
                ConfigureAwait(false);
        }

        public async Task<IEnumerable<AvaliacaoSerie>> GetAllByUserIdAsync(Guid userId)
        {
            return await _context.
                AvaliacaoSeries.
                Where(i => i.UsuarioId == userId).
                ToListAsync().
                ConfigureAwait(false);
        }

        public async Task AddAsync(AvaliacaoSerie avaliacao)
        {
            _context.Add(avaliacao);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(AvaliacaoSerie avaliacao)
        {
            _context.Update(avaliacao);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(Guid id)
        {
            var avaliacao = await _context.AvaliacaoSeries.FindAsync(id);
            if (avaliacao != null)
            {
                _context.AvaliacaoSeries.Remove(avaliacao);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
