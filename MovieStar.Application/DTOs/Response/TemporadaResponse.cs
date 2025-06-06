namespace MovieStar.Application.DTOs.Response
{
    public sealed record TemporadaResponse(
        Guid TemporadaId,
        int Numero,
        DateTime DataLancamento,
        List<EpisodioResponse> Episodios,
        SerieResponse Serie);
}
