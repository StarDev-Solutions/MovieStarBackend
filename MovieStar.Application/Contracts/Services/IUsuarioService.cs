using MovieStar.Application.DTOs.Request;
using MovieStar.Application.DTOs.Response;

namespace MovieStar.Application.Contracts.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioResponse> LoginAsync(LoginRequest loginRequest);
        Task<UsuarioResponse> GetByEmailAsync(string email);
        Task<UsuarioResponse> GetByIdAsync(Guid id);
        Task<IEnumerable<UsuarioResponse>> GetAllAsync();
        Task AddAsync(RegistroRequest usuario);
        Task UpdateAsync(RegistroRequest usuario);
        Task DeleteAsync(string email);
    }
}