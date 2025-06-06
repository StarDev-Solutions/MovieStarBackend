using AutoMapper;
using MovieStar.Application.Contracts.Services;
using MovieStar.Application.DTOs.Request;
using MovieStar.Application.DTOs.Response;
using MovieStar.Domain.Entities;
using MovieStar.Domain.Repositories;

namespace MovieStar.Application.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;
        private readonly IMapper _mapper;

        public GeneroService(IGeneroRepository generoRepository, IMapper mapper)
        {
            _generoRepository = generoRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(GeneroRequest generoRequest)
        {
            var genero = _mapper.Map<Genero>(generoRequest);
            await _generoRepository.AddAsync(genero);
        }

        public async Task DeleteAsync(Guid id)
        {
            var existente = await _generoRepository.GetByIdAsync(id);
            if (existente == null)
                throw new Exception("Gênero não encontrado.");

            await _generoRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<GeneroResponse>> GetAllAsync()
        {
            var generos = await _generoRepository.GetAllAsync();
            if (generos == null || !generos.Any())
                return Enumerable.Empty<GeneroResponse>();

            return _mapper.Map<IEnumerable<GeneroResponse>>(generos);
        }

        public async Task<GeneroResponse> GetByIdAsync(Guid id)
        {
            var genero = await _generoRepository.GetByIdAsync(id);
            if (genero == null)
                throw new Exception("Gênero não encontrado.");

            return _mapper.Map<GeneroResponse>(genero);
        }

        public async Task UpdateAsync(GeneroRequest generoRequest)
        {
            var existente = await _generoRepository.GetByIdAsync(generoRequest.Id);
            if (existente == null)
                throw new Exception("Gênero não encontrado.");

            if (!existente.Nome.Equals(generoRequest.Nome))
            {
                existente.AlterarNome(generoRequest.Nome);
            }

            await _generoRepository.UpdateAsync(existente);
        }
    }
}
