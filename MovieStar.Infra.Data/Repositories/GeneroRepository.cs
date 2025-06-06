using Microsoft.EntityFrameworkCore;
using MovieStar.Domain.Entities;
using MovieStar.Domain.Repositories;
using MovieStar.Infra.Data.Persistence;

namespace MovieStar.Infra.Data.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly ApplicationDbContext _context;

        public GeneroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Genero?> GetByIdAsync(Guid id)
        {
            return await _context.Generos.
                AsNoTracking().
                FirstOrDefaultAsync(i => i.Id == id).
                ConfigureAwait(false);
        }

        public async Task<IEnumerable<Genero>> GetAllAsync()
        {
            return await _context.Generos.ToListAsync().ConfigureAwait(false);
        }

        public async Task AddAsync(Genero genero)
        {
            _context.Add(genero);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(Genero genero)
        {
            _context.Update(genero);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(Guid id)
        {
            var genero = await _context.Generos.FindAsync(id);
            if (genero != null)
            {
                _context.Generos.Remove(genero);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
