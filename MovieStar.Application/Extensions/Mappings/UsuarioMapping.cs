using MovieStar.Application.DTOs.Request;
using MovieStar.Application.DTOs.Response;
using MovieStar.Domain.Entities;

namespace MovieStar.Application.Extensions.Mappings
{
    public static class UsuarioMapping
    {
        #region Mapeamento de RegistroRequest para Usuario
        public static Usuario Map(this RegistroRequest usuarioRequest)
        {
            return new Usuario
            (
                usuarioRequest.Nome,
                usuarioRequest.Email,
                usuarioRequest.Senha,
                new(),
                new(),
                usuarioRequest.Assinante,
                usuarioRequest.Role,
                usuarioRequest.Imagem
            );
        }
        #endregion

        #region Mapeamento de Usuario para UsuarioResponse
        public static UsuarioResponse Map(this Usuario usuario)
        {
            return new UsuarioResponse
            (   
                usuario.Id,
                usuario.Nome,
                usuario.Email,
                usuario.AvaliacoesFilme?.Select(avalicacaoFilme => new AvaliacaoFilmeResponse(
                    avalicacaoFilme.Id,
                    avalicacaoFilme.UsuarioId,
                    avalicacaoFilme.Comentario,
                    avalicacaoFilme.Nota,
                    avalicacaoFilme.DataAvaliacao,
                    avalicacaoFilme.FilmeId
                )).ToList(),
                usuario.AvaliacoesSerie?.Select(avalicaoSerie => new AvaliacaoSerieResponse(
                    avalicaoSerie.Id,
                    avalicaoSerie.UsuarioId,
                    avalicaoSerie.Comentario,
                    avalicaoSerie.Nota,
                    avalicaoSerie.DataAvaliacao,
                    avalicaoSerie.SerieId
                )).ToList(),
                usuario.Imagem
                );
        }
        #endregion
    
    }
}
