using AutoMapper;
using MovieStar.Application.Contracts.Services;
using MovieStar.Application.DTOs.Request;
using MovieStar.Application.DTOs.Response;
using MovieStar.Domain.Entities;
using MovieStar.Domain.Repositories;

public class SerieService : ISerieService
{
    private readonly ISerieRepository _serieRepository;
    private readonly IMapper _mapper;

    public SerieService(ISerieRepository serieRepository, IMapper mapper)
    {
        _serieRepository = serieRepository;
        _mapper = mapper;
    }

    public async Task AddAsync(SerieRequest serieRequest)
    {
        var serie = _mapper.Map<Serie>(serieRequest);
        await _serieRepository.AddAsync(serie);
    }

    public async Task DeleteAsync(Guid id)
    {
        var existente = await _serieRepository.GetByIdAsync(id);
        if (existente == null)
            throw new Exception("Série não encontrada.");

        await _serieRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<SerieResponse>> GetAllAsync()
    {
        var series = await _serieRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<SerieResponse>>(series);
    }

    public async Task<IEnumerable<SerieResponse>> GetAllRangeAsync(int skip, int take)
    {
        var series = await _serieRepository.GetAllRangeAsync(skip, take);
        return _mapper.Map<IEnumerable<SerieResponse>>(series);
    }

    public async Task<IEnumerable<SerieResponse>> GetByGenreAsync(string genre)
    {
        var series = await _serieRepository.GetByGenreAsync(genre);
        return _mapper.Map<IEnumerable<SerieResponse>>(series);
    }

    public async Task<SerieResponse> GetByIdAsync(Guid id)
    {
        var serie = await _serieRepository.GetByIdAsync(id);
        if (serie == null)
            throw new Exception("Série não encontrada.");

        return _mapper.Map<SerieResponse>(serie);
    }

    public async Task<SerieResponse> GetByNameAsync(string name)
    {
        var serie = await _serieRepository.GetByNameAsync(name);
        if (serie == null)
            throw new Exception("Série não encontrada.");

        return _mapper.Map<SerieResponse>(serie);
    }

    public async Task<IEnumerable<SerieResponse>> GetByRatingRangeAsync(double minRating, double maxRating)
    {
        var series = await _serieRepository.GetByRatingRangeAsync(minRating, maxRating);
        return _mapper.Map<IEnumerable<SerieResponse>>(series);
    }

    public async Task<IEnumerable<SerieResponse>> GetByReleaseDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        var series = await _serieRepository.GetByReleaseDateRangeAsync(startDate, endDate);
        return _mapper.Map<IEnumerable<SerieResponse>>(series);
    }

    public async Task UpdateAsync(SerieRequest serieRequest)
    {
        var existente = await _serieRepository.GetByIdAsync(serieRequest.Id);
        if (existente == null)
            throw new Exception("Série não encontrada.");

        if (!existente.Nome.Equals(serieRequest.Nome))
            existente.AtualizarNome(serieRequest.Nome);

        if (!existente.Descricao.Equals(serieRequest.Descricao))
            existente.AtualizarDescricao(serieRequest.Descricao);

        if (existente.Classificacao != serieRequest.Classificacao)
            existente.AtualizarClassificacao(serieRequest.Classificacao);

        if (existente.FaixaEtaria != serieRequest.FaixaEtaria)
            existente.AtualizarFaixaEtaria(serieRequest.FaixaEtaria);

        if (existente.Imagem != serieRequest.Imagem)
            existente.AtualizarImagem(serieRequest.Imagem);

        if(existente.Origem != serieRequest.Origem)
            existente.AtualizarOrigem(serieRequest.Origem);

        await _serieRepository.UpdateAsync(existente);
    }
}