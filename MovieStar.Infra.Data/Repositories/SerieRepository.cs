using Microsoft.EntityFrameworkCore;
using MovieStar.Domain.Entities;
using MovieStar.Domain.Repositories;
using MovieStar.Infra.Data.Persistence;

namespace MovieStar.Infra.Data.Repositories
{
    public class SerieRepository : ISerieRepository
    {
        private readonly ApplicationDbContext _context;

        public SerieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Serie?> GetByIdAsync(Guid id)
        {
            return await _context.Series.
                AsNoTracking().
                Include(i => i.Genero).
                Include(i => i.Elenco).
                Include(i => i.Avaliacoes).
                Include(i => i.Temporada).
                FirstOrDefaultAsync(i => i.Id == id).
                ConfigureAwait(false);
        }

        public async Task<Serie?> GetByNameAsync(string name)
        {
            return await _context.Series.
                AsNoTracking().
                Include(i => i.Genero).
                Include(i => i.Elenco).
                Include(i => i.Avaliacoes).
                Include(i => i.Temporada).
                FirstOrDefaultAsync(i => i.Nome == name).
                ConfigureAwait(false);
        }

        public async Task<IEnumerable<Serie>> GetAllAsync()
        {
            return await _context.Series.
                 AsNoTracking().
                 Include(i => i.Genero).
                 Include(i => i.Elenco).
                 Include(i => i.Avaliacoes).
                 Include(i => i.Temporada).
                 ToListAsync().
                 ConfigureAwait(false);
        }

        public async Task<IEnumerable<Serie>> GetAllRangeAsync(int skip, int take)
        {
            return await _context.Series.
                AsNoTracking().
                Include(i => i.Genero).
                Include(i => i.Elenco).
                Include(i => i.Avaliacoes).
                Include(i => i.Temporada).
                Skip(skip).
                Take(take).
                ToListAsync().
                ConfigureAwait(false);
        }

        public async Task<IEnumerable<Serie>> GetByGenreAsync(string genre)
        {
            return await _context.Series.
                AsNoTracking().
                Include(i => i.Genero).
                Include(i => i.Elenco).
                Include(i => i.Avaliacoes).
                Include(i => i.Temporada).
                Where(i => i.Genero.Any(j => j.Nome == genre)).
                ToListAsync().
                ConfigureAwait(false);
        }

        public async Task<IEnumerable<Serie>> GetByRatedAsync(int rated)
        {
            return await _context.Series.
                AsNoTracking().
                Include(i => i.Genero).
                Include(i => i.Elenco).
                Include(i => i.Avaliacoes).
                Include(i => i.Temporada).
                Where(i => i.Avaliacoes.Any(j => j.Nota == rated)).
                ToListAsync().
                ConfigureAwait(false);
        }

        public async Task<IEnumerable<Serie>> GetByReleaseDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Series.
                AsNoTracking().
                Include(i => i.Genero).
                Include(i => i.Elenco).
                Include(i => i.Avaliacoes).
                Include(i => i.Temporada).
                Where(i => i.Temporada.Any(j => j.DataLancamento >= startDate && j.DataLancamento <= endDate)).
                ToListAsync().
                ConfigureAwait(false);
        }

        public async Task<IEnumerable<Serie>> GetByRatingRangeAsync(double minRating, double maxRating)
        {
            return await _context.Series.
                AsNoTracking().
                Include(i => i.Genero).
                Include(i => i.Elenco).
                Include(i => i.Avaliacoes).
                Include(i => i.Temporada).
                Where(f => f.Avaliacoes.Any(g => g.Nota >= minRating && g.Nota <= maxRating)).
                ToListAsync().
                ConfigureAwait(false);
        }

        public async Task AddAsync(Serie serie)
        {
            _context.Series.Add(serie);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(Serie serie)
        {
            _context.Series.Update(serie);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(Guid id)
        {
            var serie = await _context.Series.FindAsync(id);
            if (serie != null)
            {
                _context.Series.Remove(serie);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
