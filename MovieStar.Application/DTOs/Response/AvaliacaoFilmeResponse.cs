namespace MovieStar.Application.DTOs.Response
{
    public sealed record AvaliacaoFilmeResponse(
        Guid AvaliacaoId,
        Guid UsuarioId,
        string Comentario,
        double Nota,
        DateTime DataAvaliacao,
        Guid FilmeId);
}