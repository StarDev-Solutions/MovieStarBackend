using AutoMapper;
using MovieStar.Application.Contracts.Services;
using MovieStar.Application.DTOs.Request;
using MovieStar.Application.DTOs.Response;
using MovieStar.Domain.Entities;
using MovieStar.Domain.Repositories;

namespace MovieStar.Application.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;
        private readonly IMapper _mapper;

        public FilmeService(IFilmeRepository filmeRepository, IMapper mapper)
        {
            _filmeRepository = filmeRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(FilmeRequest filmeRequest)
        {
            var filme = _mapper.Map<Filme>(filmeRequest);
            await _filmeRepository.AddAsync(filme);
        }

        public async Task DeleteAsync(Guid id)
        {
            var filme = await _filmeRepository.GetByIdAsync(id);
            if (filme == null)
                throw new Exception("Filme não encontrado.");

            await _filmeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<FilmeResponse>> GetAllAsync()
        {
            var filmes = await _filmeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FilmeResponse>>(filmes);
        }

        public async Task<IEnumerable<FilmeResponse>> GetAllRangeAsync(int skip, int take)
        {
            var filmes = await _filmeRepository.GetAllRangeAsync(skip, take);
            return _mapper.Map<IEnumerable<FilmeResponse>>(filmes);
        }

        public async Task<IEnumerable<FilmeResponse>> GetByGenreAsync(string genre)
        {
            var filmes = await _filmeRepository.GetByGenreAsync(genre);
            return _mapper.Map<IEnumerable<FilmeResponse>>(filmes);
        }

        public async Task<FilmeResponse> GetByIdAsync(Guid id)
        {
            var filme = await _filmeRepository.GetByIdAsync(id);
            if (filme == null)
                throw new Exception("Filme não encontrado.");

            return _mapper.Map<FilmeResponse>(filme);
        }

        public async Task<FilmeResponse> GetByNameAsync(string name)
        {
            var filme = await _filmeRepository.GetByNameAsync(name);
            if (filme == null)
                throw new Exception("Filme não encontrado.");

            return _mapper.Map<FilmeResponse>(filme);
        }

        public async Task<IEnumerable<FilmeResponse>> GetByRatedAsync(int rated)
        {
            var filmes = await _filmeRepository.GetByRatedAsync(rated);
            return _mapper.Map<IEnumerable<FilmeResponse>>(filmes);
        }

        public async Task<IEnumerable<FilmeResponse>> GetByRatingRangeAsync(double minRating, double maxRating)
        {
            var filmes = await _filmeRepository.GetByRatingRangeAsync(minRating, maxRating);
            return _mapper.Map<IEnumerable<FilmeResponse>>(filmes);
        }

        public async Task<IEnumerable<FilmeResponse>> GetByReleaseDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var filmes = await _filmeRepository.GetByReleaseDateRangeAsync(startDate, endDate);
            return _mapper.Map<IEnumerable<FilmeResponse>>(filmes);
        }

        public async Task UpdateAsync(FilmeRequest filmeRequest)
        {
            var existente = await _filmeRepository.GetByIdAsync(filmeRequest.Id);
            if (existente == null)
                throw new Exception("Filme não encontrado.");

            if (!existente.Nome.Equals(filmeRequest.Nome))
            {
                existente.AtualizarNome(filmeRequest.Nome);
            }
            if (!existente.Descricao.Equals(filmeRequest.Descricao))
            {
                existente.AtualizarDescricao(filmeRequest.Descricao);
            }
            if(existente.DataLancamento != filmeRequest.DataLancamento)
            {
                existente.AtualizarDataLancamento(filmeRequest.DataLancamento);
            }
            if (existente.FaixaEtaria != filmeRequest.FaixaEtaria)
            {
                existente.AtualizarFaixaEtaria(filmeRequest.FaixaEtaria);
            }
            if (existente.Duracao != filmeRequest.Duracao)
            {
                existente.AtualizarDuracao(filmeRequest.Duracao);
            }
            if (existente.Imagem != filmeRequest.Imagem)
            {
                existente.AtualizarImagem(filmeRequest.Imagem);
            }
            if (existente.Origem != filmeRequest.Origem)
            {
                existente.AtualizarOrigem(filmeRequest.Origem);
            }
            await _filmeRepository.UpdateAsync(existente);
        }
    }
}
