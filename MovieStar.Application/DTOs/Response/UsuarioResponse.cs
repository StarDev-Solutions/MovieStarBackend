namespace MovieStar.Application.DTOs.Response
{
    public sealed record UsuarioResponse(
        Guid UsuarioId,
        string Nome,
        string Email,
        List<AvaliacaoFilmeResponse>? AvaliacoesFilme,
        List<AvaliacaoSerieResponse>? AvaliacoesSerie,
        byte[]? Imagem,
        string Token,
        string RefreshToken
        );
}