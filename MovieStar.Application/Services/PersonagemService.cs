using AutoMapper;
using MovieStar.Application.Contracts.Services;
using MovieStar.Application.DTOs.Request;
using MovieStar.Application.DTOs.Response;
using MovieStar.Domain.Entities;
using MovieStar.Domain.Repositories;

namespace MovieStar.Application.Services
{
    public class PersonagemService : IPersonagemService
    {
        private readonly IPersonagemRepository _personagemRepository;
        private readonly IMapper _mapper;

        public PersonagemService(IPersonagemRepository personagemRepository, IMapper mapper)
        {
            _personagemRepository = personagemRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(PersonagemRequest personagemRequest)
        {
            var personagem = _mapper.Map<Personagem>(personagemRequest);
            await _personagemRepository.AddAsync(personagem);
        }

        public async Task DeleteAsync(Guid id)
        {
            var existente = await _personagemRepository.GetByIdAsync(id);
            if (existente == null)
                throw new Exception("Personagem não encontrado.");

            await _personagemRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PersonagemResponse>> GetAllAsync()
        {
            var personagens = await _personagemRepository.GetAllAsync();
            if (personagens == null || !personagens.Any())
                return Enumerable.Empty<PersonagemResponse>();

            return _mapper.Map<IEnumerable<PersonagemResponse>>(personagens);
        }

        public async Task<PersonagemResponse> GetAllByActorNameAsync(string actorName)
        {
            var personagem = await _personagemRepository.GetAllByActorNameAsync(actorName);
            if (personagem == null)
                throw new Exception("Personagem não encontrado.");

            return _mapper.Map<PersonagemResponse>(personagem);
        }

        public async Task<PersonagemResponse> GetByIdAsync(Guid id)
        {
            var personagem = await _personagemRepository.GetByIdAsync(id);
            if (personagem == null)
                throw new Exception("Personagem não encontrado.");

            return _mapper.Map<PersonagemResponse>(personagem);
        }

        public async Task UpdateAsync(PersonagemRequest personagemRequest)
        {
            var existente = await _personagemRepository.GetByIdAsync(personagemRequest.Id);
            if (existente == null)
                throw new Exception("Personagem não encontrado.");

            if (!existente.NomePersonagem.Equals(personagemRequest.NomePersonagem))
                existente.AlterarNomePersonagem(personagemRequest.NomePersonagem);

            if (!existente.NomeAtor.Equals(personagemRequest.NomeAtor))
                existente.AlterarNomeAtor(personagemRequest.NomeAtor);

            if (existente.Imagem != personagemRequest.Imagem)
                existente.AlterarImagem(personagemRequest.Imagem);

            await _personagemRepository.UpdateAsync(existente);
        }
    }
}