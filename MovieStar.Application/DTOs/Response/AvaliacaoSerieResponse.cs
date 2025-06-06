namespace MovieStar.Application.DTOs.Response
{
    public sealed record AvaliacaoSerieResponse(
        Guid AvaliacaoId,
        UsuarioResponse UsuarioId,
        string Comentario,
        double Nota,
        DateTime DataAvaliacao,
        SerieResponse Serie);
}