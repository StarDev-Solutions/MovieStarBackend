using AutoMapper;
using MovieStar.Application.Contracts.Services;
using MovieStar.Application.DTOs.Request;
using MovieStar.Application.DTOs.Response;
using MovieStar.Domain.Entities;
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

        public async Task AddAsync(RegistroRequest usuarioRequest)
        {
            var usuario = _mapper.Map<Usuario>(usuarioRequest);
            await _usuarioRepository.AddAsync(usuario);
        }

        public async Task DeleteAsync(Guid id)
        {
            //var existente = await _usuarioRepository.GetByEmailAsync(id);
            //if (existente == null)
            //    throw new Exception("Usuário não encontrado.");

            //await _usuarioRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        public async Task<UsuarioResponse> GetByEmailAsync(string email)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(email);
            if (usuario == null)
                throw new Exception("Usuário não encontrado.");

            return _mapper.Map<UsuarioResponse>(usuario);
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

            if (!string.Equals(existente.Senha, usuarioRequest.Senha))
                existente.AlterarSenha(usuarioRequest.Senha);

            await _usuarioRepository.UpdateAsync(existente);
        }
    }
}
