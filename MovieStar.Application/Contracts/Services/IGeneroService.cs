using MovieStar.Application.DTOs.Request;
using MovieStar.Application.DTOs.Response;

namespace MovieStar.Application.Contracts.Services
{
    public interface IGeneroService
    {
        Task<GeneroResponse> GetByIdAsync(Guid id);
        Task<IEnumerable<GeneroResponse>> GetAllAsync();
        Task AddAsync(GeneroRequest genero);
        Task UpdateAsync(GeneroRequest genero);
        Task DeleteAsync(Guid id);
    }
}