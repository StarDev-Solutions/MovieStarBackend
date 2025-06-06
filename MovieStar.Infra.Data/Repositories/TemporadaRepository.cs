using Microsoft.EntityFrameworkCore;
using MovieStar.Domain.Entities;
using MovieStar.Domain.Repositories;
using MovieStar.Infra.Data.Persistence;

namespace MovieStar.Infra.Data.Repositories
{
    public class TemporadaRepository : ITemporadaRepository
    {
        ApplicationDbContext _context;

        public TemporadaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Temporada?> GetByIdAsync(Guid id)
        {
            return await _context.Temporadas.
                AsNoTracking().
                Include(i => i.Episodio).
                FirstOrDefaultAsync(i => i.Id == id).
                ConfigureAwait(false);
        }

        public async Task<Temporada?> GetByNumberSeriesAsync(int number, Guid seriesID)
        {
            return await _context.
                Temporadas.
                Include(t => t.Episodio).
                FirstOrDefaultAsync(t => t.Numero == number && t.SerieId == seriesID).
                ConfigureAwait(false);
        }

        public async Task<IEnumerable<Temporada>> GetBySeriesAsync(Guid seriesId)
        {
            return await _context.Temporadas.Where(i => i.SerieId == seriesId).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Temporada>?> GetAllAsync()
        {
            return await _context.Temporadas.ToListAsync().ConfigureAwait(false);
        }

        public async Task AddAsync(Temporada temporada)
        {
            _context.Add(temporada);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(Temporada temporada)
        {
            _context.Update(temporada);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(Guid id)
        {
            var temporada = await _context.Temporadas.FindAsync(id);
            if (temporada != null)
            {
                _context.Temporadas.Remove(temporada);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
