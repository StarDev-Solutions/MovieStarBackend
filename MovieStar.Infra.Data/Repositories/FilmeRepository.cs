using Microsoft.EntityFrameworkCore;
using MovieStar.Domain.Entities;
using MovieStar.Domain.Repositories;
using MovieStar.Infra.Data.Persistence;

namespace MovieStar.Infra.Data.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        ApplicationDbContext _context;

        public FilmeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Filme?> GetByIdAsync(Guid id)
        {
            return await _context.Filmes.
                AsNoTracking().
                Include(i => i.Genero).
                Include(i => i.Elenco).
                Include(i => i.Avaliacoes).
                FirstOrDefaultAsync(i => i.Id == id).
                ConfigureAwait(false);
        }

        public async Task<Filme?> GetByNameAsync(string name)
        {
            return await _context.Filmes.
                AsNoTracking().
                Include(i => i.Genero).
                Include(i => i.Elenco).
                Include(i => i.Avaliacoes).
                FirstOrDefaultAsync(i => i.Nome == name).
                ConfigureAwait(false);
        }

        public async Task<IEnumerable<Filme>> GetAllAsync()
        {
            return await _context.Filmes.
                 AsNoTracking().
                 Include(i => i.Genero).
                 Include(i => i.Elenco).
                 Include(i => i.Avaliacoes).
                 ToListAsync().
                 ConfigureAwait(false);
        }

        public async Task<IEnumerable<Filme>> GetAllRangeAsync(int skip, int take)
        {
            return await _context.Filmes.
                AsNoTracking().
                Include(i => i.Genero).
                Include(i => i.Elenco).
                Include(i => i.Avaliacoes).
                Skip(skip).
                Take(take).
                OrderBy(f=>f.Nome).
                ToListAsync().
                ConfigureAwait(false);
        }

        public async Task<IEnumerable<Filme>> GetByGenreAsync(string genre)
        {
            return await _context.Filmes.
                AsNoTracking().
                Include(i => i.Genero).
                Include(i => i.Elenco).
                Include(i => i.Avaliacoes).
                Where(i => i.Genero.Any(j => j.Nome == genre)).
                ToListAsync().
                ConfigureAwait(false);
        }

        public async Task<IEnumerable<Filme>> GetByRatedAsync(int rated)
        {
            return await _context.Filmes.
                AsNoTracking().
                Include(i => i.Genero).
                Include(i => i.Elenco).
                Include(i => i.Avaliacoes).
                Where(i => i.Avaliacoes.Any(j => j.Nota == rated)).
                ToListAsync().
                ConfigureAwait(false);
        }

        public async Task<IEnumerable<Filme>> GetByReleaseDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Filmes.
                AsNoTracking().
                Include(i => i.Genero).
                Include(i => i.Elenco).
                Include(i => i.Avaliacoes).
                Where(f => f.DataLancamento >= startDate && f.DataLancamento <= endDate).
                ToListAsync().
                ConfigureAwait(false);
        }

        public async Task<IEnumerable<Filme>> GetByRatingRangeAsync(double minRating, double maxRating)
        {
            return await _context.Filmes.
                AsNoTracking().
                Include(i => i.Genero).
                Include(i => i.Elenco).
                Include(i => i.Avaliacoes).
                Where(f => f.Avaliacoes.Any(g => g.Nota >= minRating && g.Nota <= maxRating)).
                ToListAsync().
                ConfigureAwait(false);
        }

        public async Task AddAsync(Filme filme)
        {
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(Filme filme)
        {
            _context.Filmes.Update(filme);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(Guid id)
        {
            var filme = await _context.Filmes.FindAsync(id);
            if (filme != null)
            {
                _context.Filmes.Remove(filme);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }        
    }
}