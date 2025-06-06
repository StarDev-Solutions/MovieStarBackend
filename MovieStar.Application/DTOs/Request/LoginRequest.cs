using System.ComponentModel.DataAnnotations;

namespace MovieStar.Application.DTOs.Request
{
    public sealed record LoginRequest(
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail deve ser válido.")]
        string Email,
        [Required(ErrorMessage = "A senha é obrigatória")]
        string Senha
        );
}