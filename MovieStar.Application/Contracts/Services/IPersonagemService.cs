using MovieStar.Application.DTOs.Request;
using MovieStar.Application.DTOs.Response;

namespace MovieStar.Application.Contracts.Services
{
    public interface IPersonagemService
    {
        Task<PersonagemResponse> GetByIdAsync(Guid id);
        Task<PersonagemResponse> GetAllByActorNameAsync(string actorName);
        Task<IEnumerable<PersonagemResponse>> GetAllAsync();
        Task AddAsync(PersonagemRequest personagem);
        Task UpdateAsync(PersonagemRequest personagem);
        Task DeleteAsync(Guid id);
    }
}