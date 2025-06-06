using Microsoft.EntityFrameworkCore;
using MovieStar.Domain.Entities;
using MovieStar.Domain.Repositories;
using MovieStar.Infra.Data.Persistence;

namespace MovieStar.Infra.Data.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonagemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Personagem?> GetByIdAsync(Guid id)
        {
            return await _context.Personagens.
                AsNoTracking().
                FirstOrDefaultAsync(i => i.Id == id).
                ConfigureAwait(false);
        }

        public async Task<IEnumerable<Personagem>> GetAllAsync()
        {
            return await _context.Personagens.ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Personagem>> GetAllByActorNameAsync(string actorName)
        {
            return await _context.
                Personagens.
                Where(i => i.NomeAtor == actorName).
                ToListAsync().
                ConfigureAwait(false);
        }

        public async Task<IEnumerable<Personagem>> GetAllMovieIdAsync(Guid filmeId)
        {
            return await _context.Filmes
                .Where(f => f.Id == filmeId)
                .SelectMany(f => f.Elenco)
                .ToListAsync().
                ConfigureAwait(false);
        }

        public async Task<IEnumerable<Personagem>> GetAllSeriesIdAsync(Guid serieId)
        {
            return await _context.Series
                .Where(s => s.Id == serieId)
                .SelectMany(s => s.Elenco)
                .ToListAsync().
                ConfigureAwait(false);
        }

        public async Task AddAsync(Personagem personagem)
        {
            _context.Add(personagem);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(Personagem personagem)
        {
            _context.Update(personagem);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(Guid id)
        {
            var personagem = await _context.Personagens.FindAsync(id);
            if (personagem != null)
            {
                _context.Personagens.Remove(personagem);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
