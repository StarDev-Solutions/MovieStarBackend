using System.ComponentModel.DataAnnotations;

namespace MovieStar.Application.DTOs.Request
{
    public sealed record AvaliacaoRequest(
        [Required] 
        Guid UsuarioId,
        [Required] 
        Guid Id,
        [Required(ErrorMessage = "O comentário é obrigatório.")]
        [StringLength(500, ErrorMessage = "O comentário deve ter no máximo 500 caracteres.")]
        string Comentario,
        [Required(ErrorMessage = "A nota é obrigatória.")]
        [Range(0, 5, ErrorMessage = "A nota deve estar entre 0 e 5.")]
        double Nota
        );
}