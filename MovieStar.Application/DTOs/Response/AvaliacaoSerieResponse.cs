namespace MovieStar.Application.DTOs.Response
{
    public sealed record AvaliacaoSerieResponse(
        Guid AvaliacaoId,
        Guid UsuarioId,
        string Comentario,
        double Nota,
        DateTime DataAvaliacao,
        Guid SerieId);
}