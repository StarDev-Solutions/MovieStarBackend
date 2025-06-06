namespace MovieStar.Application.DTOs.Response
{
    public sealed record PersonagemResponse(
        Guid PersonagemId,
        string NomePersonagem,
        string NomeAtor,
        byte[]? Imagem
        );
}
