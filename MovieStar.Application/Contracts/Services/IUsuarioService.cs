using MovieStar.Application.DTOs.Request;
using MovieStar.Application.DTOs.Response;
using MovieStar.Domain.Entities;

namespace MovieStar.Application.Contracts.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioResponse> GetByEmailAsync(string email);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task AddAsync(RegistroRequest usuario);
        Task UpdateAsync(RegistroRequest usuario);
        Task DeleteAsync(Guid id);
    }
}