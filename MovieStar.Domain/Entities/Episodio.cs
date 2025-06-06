using MovieStar.Domain.Shared.Entities;

namespace MovieStar.Domain.Entities
{
    public sealed class Episodio : BaseEntity
    {
        public int Numero { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public int Duracao { get; private set; }
        public byte[]? Imagem { get; private set; }
        public Guid TemporadaId { get; private set; }
        public Temporada Temporada { get; private set; }


        public Episodio() : base(Guid.NewGuid()) {}
        public Episodio(int numero, string nome, string descricao, int duracao, byte[]? imagem, Guid temporadaId, Temporada temporada) : base(Guid.NewGuid())
        {
            Numero = numero;
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Descricao = descricao ?? string.Empty;
            Duracao = duracao;
            Imagem = imagem ?? Array.Empty<byte>();
            TemporadaId = temporadaId;
            Temporada = temporada;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
        }

        public void AlterarDescricao(string descricao)
        {
            Descricao = descricao ?? string.Empty;
        }

        public void AlterarDuracao(int duracao)
        {
            Duracao = duracao;
        }

        public void AlterarImagem(byte[] imagem)
        {
            Imagem = imagem ?? Array.Empty<byte>();
        }
    }
}