using System.ComponentModel.DataAnnotations;

namespace MovieStar.Application.DTOs.Request
{
    public sealed record GeneroRequest(
        [Required]
        Guid Id,
        [Required(ErrorMessage = "O nome do gênero é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome do gênero não pode exceder 100 caracteres.")]
        string Nome
        );
}
