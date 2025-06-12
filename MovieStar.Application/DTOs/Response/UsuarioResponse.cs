namespace MovieStar.Application.DTOs.Response
{
    public sealed record UsuarioResponse(
        Guid Id,
        string Nome,
        string Email,
        List<AvaliacaoFilmeResponse>? AvaliacoesFilme,
        List<AvaliacaoSerieResponse>? AvaliacoesSerie,
        byte[]? Imagem
        );
}