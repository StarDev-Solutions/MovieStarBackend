using MovieStar.Application.Utils.Validations;
using System.ComponentModel.DataAnnotations;

namespace MovieStar.Application.DTOs.Request
{
    public sealed record RegistroRequest(
        [Required(ErrorMessage = "O nome é obrigatório.")]
        string Nome,
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail deve ser válido.")]
        string Email,
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [CustomValidation(typeof(PasswordValidation), nameof(PasswordValidation.PasswordValidate))]
        string Senha,
        byte[]? Imagem = null,
        bool Assinante = false,
        string Role = "Usuario"
        );
}