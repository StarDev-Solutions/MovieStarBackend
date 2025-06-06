using System.ComponentModel.DataAnnotations;

namespace MovieStar.Application.DTOs.Request
{
    public sealed record SerieRequest(
        [Required]
        Guid Id,
        [Required(ErrorMessage ="O nome da série é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome da série deve ter no máximo 100 caracteres.")]
        string Nome,
        [Required(ErrorMessage = "A descrição da série é obrigatória.")]
        [StringLength(500, ErrorMessage = "A descrição da série deve ter no máximo 500 caracteres.")]
        string Descricao,
        [Required(ErrorMessage = "O genero é obrigatório.")]
        List<GeneroRequest> Genero,
        [Required(ErrorMessage = "O elenco é obrigatório.")]
        List<PersonagemRequest> Elenco,
        byte[]? Imagem,
        [Required(ErrorMessage = "A classificação indicativa é obrigatória.")]
        [Range(0, 18, ErrorMessage = "A classificação indicativa deve estar entre 0 e 18.")]
        int FaixaEtaria,
        double? Classificacao,
        [Required(ErrorMessage = "A origem da série é obrigatória.")]
        string Origem,
        List<AvaliacaoRequest>? Avaliacoes,
        List<TemporadaRequest> Temporadas
        );
}