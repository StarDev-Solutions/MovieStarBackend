using AutoMapper;
using MovieStar.Application.Contracts.Services;
using MovieStar.Application.DTOs.Request;
using MovieStar.Application.DTOs.Response;
using MovieStar.Application.Extensions.Mappings;
using MovieStar.Application.Utils.Hash;
using MovieStar.Domain.Repositories;

namespace MovieStar.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioResponse> LoginAsync(LoginRequest login)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(login.Email);
            if (usuario == null)
                throw new Exception("Usuário não encontrado.");
            if (usuario == null || !PasswordHash.VerifyPassword(login.Senha, usuario.Senha))
                throw new Exception("Usuário ou senha inválidos.");

             // FAZER O JWT E RETORNAR JUNTAMENTE DO USUARIO
             return usuario.Map();
        }

        public async Task AddAsync(RegistroRequest usuarioRequest)
        {
            var existente = await _usuarioRepository.GetByEmailAsync(usuarioRequest.Email);
            if (existente != null)
                throw new Exception("Usuário já cadastrado com este e-mail.");

            var usuario = usuarioRequest.Map();
            usuario.AtualizarSenha(PasswordHash.CryptPassword(usuarioRequest.Senha));
            await _usuarioRepository.AddAsync(usuario);
        }

        public async Task DeleteAsync(string email)
        {
            var existente = await _usuarioRepository.GetByEmailAsync(email);
            if (existente == null)
                throw new Exception("Usuário não encontrado.");

            await _usuarioRepository.DeleteAsync(existente);
        }

        public async Task<IEnumerable<UsuarioResponse>> GetAllAsync()
        {
            var users = await _usuarioRepository.GetAllAsync();
            return users.Select(user => user.Map());
        }

        public async Task<UsuarioResponse> GetByEmailAsync(string email)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(email);
            if (usuario == null)
                throw new Exception("Usuário não encontrado.");

            return usuario.Map();
        }

        public async Task<UsuarioResponse> GetByIdAsync(Guid id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
                throw new Exception("Usuário não encontrado.");

            return usuario.Map();
        }

        public async Task UpdateAsync(RegistroRequest usuarioRequest)
        {
            var existente = await _usuarioRepository.GetByEmailAsync(usuarioRequest.Email);
            if (existente == null)
                throw new Exception("Usuário não encontrado.");

            if (!string.Equals(existente.Nome, usuarioRequest.Nome, StringComparison.OrdinalIgnoreCase))
                existente.AlterarNome(usuarioRequest.Nome);

            if (!string.Equals(existente.Email, usuarioRequest.Email, StringComparison.OrdinalIgnoreCase))
                existente.AlterarEmail(usuarioRequest.Email);

            if (!PasswordHash.VerifyPassword(usuarioRequest.Senha, existente.Senha))
                existente.AtualizarSenha(PasswordHash.CryptPassword(usuarioRequest.Senha));

            await _usuarioRepository.UpdateAsync(existente);
        }
    }
}
