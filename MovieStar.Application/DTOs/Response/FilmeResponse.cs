namespace MovieStar.Application.DTOs.Response
{
    public sealed record FilmeResponse(
        Guid FilmeId,
        string Nome,
        string Descricao,
        List<GeneroResponse> Genero,
        List<PersonagemResponse> Elenco,
        int Duracao,
        double Classificacao,
        byte[]? Imagem,
        string Origem,
        DateTime DataLancamento,
        int FaixaEtaria,
        List<AvaliacaoFilmeResponse>? Avaliacoes
        );
}
