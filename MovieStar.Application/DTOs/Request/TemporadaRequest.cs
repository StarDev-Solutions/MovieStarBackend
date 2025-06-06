using System.ComponentModel.DataAnnotations;

namespace MovieStar.Application.DTOs.Request
{
    public sealed record TemporadaRequest(
        [Required]
        Guid Id,
        [Required(ErrorMessage = "O número da temporada é obrigatório.")]
        int Numero,
        [Required(ErrorMessage = "A data de lançamento é obrigatória.")]
        DateTime DataLancamento,
        [Required(ErrorMessage = "É necessário atribuir os episódios a esta temporada")]
        List<Guid> Episodios,
        [Required(ErrorMessage = "O ID da série é obrigatório.")]
        Guid SerieId
        );
}
