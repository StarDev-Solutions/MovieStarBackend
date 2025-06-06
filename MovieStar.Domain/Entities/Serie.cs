using MovieStar.Domain.Shared.Entities;

namespace MovieStar.Domain.Entities
{
    public sealed class Serie : BaseEntity
    {
        #region Propriedades
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public List<Genero> Genero { get; private set; }
        public List<Personagem> Elenco { get; private set; }
        public byte[]? Imagem { get; private set; }
        public double Classificacao { get; private set; }
        public string Origem { get; private set; }
        public int FaixaEtaria { get; private set; }
        public List<AvaliacaoSerie>? Avaliacoes { get; private set; } = new();
        public List<Temporada> Temporada { get; private set; }
        #endregion

        #region Construtor
        private Serie() : base(Guid.NewGuid()) { }

        public Serie(string nome, string descricao, List<Genero> genero, List<Personagem> elenco,
            int faixaEtaria, byte[]? imagem, double classificacao, string origem,
             List<AvaliacaoSerie>? avaliacao, List<Temporada> temporada) : base(Guid.NewGuid())
        {
            Nome = nome;
            Descricao = descricao;
            Genero = genero;
            Elenco = elenco;
            FaixaEtaria = faixaEtaria;
            Imagem = imagem ?? Array.Empty<byte>();
            Classificacao = classificacao;
            Origem = origem;
            Avaliacoes = avaliacao;
            Temporada = temporada;
        }
        #endregion

        #region Métodos
        public void AtualizarNome(string nome)
        {
            Nome = nome;
        }
        public void AtualizarDescricao(string descricao)
        {
            Descricao = descricao;
        }
        public void AtualizarGenero(List<Genero> genero)
        {
            Genero = genero;
        }
        public void AtualizarElenco(List<Personagem> elenco)
        {
            Elenco = elenco;
        }
        public void AtualizarImagem(byte[] imagem)
        {
            Imagem = imagem;
        }
        public void AtualizarClassificacao(double classificacao)
        {
            Classificacao = classificacao;
        }
        public void AtualizarOrigem(string origem)
        {
            Origem = origem;
        }
        public void AtualizarFaixaEtaria(int faixaEtaria)
        {
            FaixaEtaria = faixaEtaria;
        }
        public void AdicionarAvaliacao(AvaliacaoSerie avaliacao)
        {
            Avaliacoes?.Add(avaliacao);
        }
        public void RemoverAvaliacao(AvaliacaoSerie avaliacao)
        {
            Avaliacoes?.Remove(avaliacao);
        }
        public void AdicionarTemporada(Temporada temporada)
        {
            Temporada.Add(temporada);
        }
        public void RemoverTemporada(Temporada temporada)
        {
            Temporada.Remove(temporada);
        }
        #endregion
    }

}
