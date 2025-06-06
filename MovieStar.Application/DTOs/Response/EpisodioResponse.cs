namespace MovieStar.Application.DTOs.Response
{
    public sealed record EpisodioResponse(
        Guid EpisodioId,
        int Numero,
        string Nome,
        string Descricao,
        int Duracao,
        byte[]? Imagem,
        TemporadaResponse TemporadaResponse
        );
}
