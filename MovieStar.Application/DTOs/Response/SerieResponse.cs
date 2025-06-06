namespace MovieStar.Application.DTOs.Response
{
    public sealed record SerieResponse(
        Guid SerieId,
        string Nome,
        string Descricao,
        List<GeneroResponse> Genero,
        List<PersonagemResponse> Elenco,
        byte[]? Imagem,
        double Classificacao,
        string Origem,
        int FaixaEtaria,
        List<AvaliacaoSerieResponse>? Avaliacoes,
        List<TemporadaResponse>? Temporadas
        );
}
