using Microsoft.EntityFrameworkCore;
using MovieStar.Domain.Entities;
using MovieStar.Domain.Repositories;
using MovieStar.Infra.Data.Persistence;

namespace MovieStar.Infra.Data.Repositories
{
    public class EpisodioRepository : IEpisodioRepository
    {
        private readonly ApplicationDbContext _context;

        public EpisodioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Episodio?> GetByIdAsync(Guid id)
        {
            return await _context.Episodios.
                AsNoTracking().
                FirstOrDefaultAsync(i => i.Id == id).
                ConfigureAwait(false);
        }

        public async Task<Episodio?> GetByNumberInSeasonAsync(int number, Guid seasonId)
        {
            return await _context.Episodios.FirstOrDefaultAsync(t => t.Numero == number && t.TemporadaId == seasonId).ConfigureAwait(false); ;
        }

        public async Task<IEnumerable<Episodio>> GetAllInSeasonAsync(Guid SeasonId)
        {
            return await _context.Episodios.Where(i => i.TemporadaId == SeasonId).ToListAsync().ConfigureAwait(false);
        }

        public async Task AddAsync(Episodio episodio)
        {
            _context.Add(episodio);
            await _context.SaveChangesAsync().
            ConfigureAwait(false);
        }

        public async Task UpdateAsync(Episodio episodio)
        {
            _context.Update(episodio);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(Guid id)
        {
            var episodio = await _context.Episodios.FindAsync(id);
            if (episodio != null)
            {
                _context.Episodios.Remove(episodio);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
