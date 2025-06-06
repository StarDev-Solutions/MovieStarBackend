using MovieStar.Domain.Shared.Entities;

namespace MovieStar.Domain.Entities
{
    public sealed class Personagem : BaseEntity
    {
        public string NomePersonagem { get; private set; }
        public string NomeAtor { get; private set; }
        public byte[]? Imagem { get; private set; }

        public Personagem()
        : base(Guid.NewGuid()) {}

        public Personagem(string nomePersonagem, string nomeAtor, byte[]? imagem) : base(Guid.NewGuid())
        {
            NomePersonagem = nomePersonagem ?? throw new ArgumentNullException(nameof(nomePersonagem));
            NomeAtor = nomeAtor ?? throw new ArgumentNullException(nameof(nomeAtor));
            Imagem = imagem ?? Array.Empty<byte>();
        }

        public void AlterarNomePersonagem(string nomePersonagem)
        {
            NomePersonagem = nomePersonagem ?? throw new ArgumentNullException(nameof(nomePersonagem));
        }

        public void AlterarNomeAtor(string nomeAtor)
        {
            NomeAtor = nomeAtor ?? throw new ArgumentNullException(nameof(nomeAtor));
        }

        public void AlterarImagem(byte[] imagem)
        {
            Imagem = imagem;
        }
    }
}
