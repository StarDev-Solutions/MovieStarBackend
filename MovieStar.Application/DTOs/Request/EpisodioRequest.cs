using System.ComponentModel.DataAnnotations;

namespace MovieStar.Application.DTOs.Request
{
    public sealed record EpisodioRequest(
        [Required]
        Guid Id,
        [Required(ErrorMessage = "O número do episódio é obrigatório.")]
        int Numero,
        [Required(ErrorMessage = "O nome do episódio é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
        string Nome,
        [Required(ErrorMessage = "A descrição do episódio é obrigatória.")]
        [StringLength(100, ErrorMessage = "A descrição deve ter no máximo 100 caracteres.")]
        string Descricao,
        [Required(ErrorMessage = "A duração do episódio é obrigatória.")]
        int Duracao,
        byte[]? Imagem);
}