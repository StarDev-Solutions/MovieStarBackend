using System.ComponentModel.DataAnnotations;

namespace MovieStar.Application.DTOs.Request
{
    public sealed record PersonagemRequest(
        [Required]
        Guid Id,
        [Required(ErrorMessage ="O nome do personagem é obrigatório")]
        string NomePersonagem,
        [Required(ErrorMessage = "O nome do ator é obrigatório")]
        string NomeAtor,
        byte[]? Imagem
        );
}
