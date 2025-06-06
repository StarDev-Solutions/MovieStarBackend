using System.ComponentModel.DataAnnotations;

namespace MovieStar.Application.DTOs.Request
{
    public sealed record FilmeRequest(
        [Required]
        Guid Id,
        [Required(ErrorMessage = "O nome do filme é obrigatório.")]
        string Nome,
        [Required(ErrorMessage = "A descrição do filme é obrigatória.")]
        [MaxLength(500, ErrorMessage = "A descrição do filme não pode exceder 500 caracteres.")]
        string Descricao,
        [Required(ErrorMessage = "O gênero do filme é obrigatório.")]
        List<GeneroRequest> Genero,
        [Required(ErrorMessage = "O elenco do filme é obrigatório.")]
        List<PersonagemRequest> Elenco,
        [Range(1, int.MaxValue, ErrorMessage = "A duração do filme deve ser maior que zero.")]
        int Duracao,
        double? Classificacao,
        byte[]? Imagem,
        [Required(ErrorMessage = "A origem do filme é obrigatória.")]
        string Origem,
        [Required(ErrorMessage = "A data de lançamento do filme é obrigatória.")]
        DateTime DataLancamento,
        [Range(0, 18, ErrorMessage = "A faixa etária deve estar entre 0 e 18 anos.")]
        int FaixaEtaria,
        List<AvaliacaoRequest>? Avaliacoes
        );
}
