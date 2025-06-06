using MovieStar.Domain.Shared.Entities;

namespace MovieStar.Domain.Entities
{
    public sealed class Filme : BaseEntity
    {
        #region Propriedades
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public List<Genero> Genero { get; private set; }
        public List<Personagem> Elenco{ get; private set; }
        public int Duracao { get; private set; }
        public double Classificacao { get; private set; }
        public byte[]? Imagem { get; private set; }
        public string Origem { get; private set; }
        public DateTime DataLancamento { get; private set; }
        public int FaixaEtaria { get; private set; }
        public List<AvaliacaoFilme>? Avaliacoes { get; private set; } = new();
        #endregion

        #region Construtor
        private Filme() : base(Guid.NewGuid()) { }

        public Filme(string nome, string descricao, List<Genero> genero, List<Personagem> elenco, 
            int duracao, double classificacao,byte[]? imagem, string origem, 
            DateTime dataLancamento,int faixaEtaria, List<AvaliacaoFilme>? avaliacao) : base(Guid.NewGuid())
        {
            Nome = nome;
            Descricao = descricao;
            Genero = genero;
            Elenco = elenco;
            Duracao = duracao;
            Classificacao = classificacao;
            Imagem = imagem ?? Array.Empty<byte>();
            Origem = origem;
            DataLancamento = dataLancamento;
            FaixaEtaria = faixaEtaria;
            Avaliacoes = avaliacao;
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
        public void AdicionarElenco(Personagem personagem)
        {
            Elenco.Add(personagem);
        }
        public void RemoverElenco(Personagem personagem)
        {
            Elenco.Remove(personagem);
        }
        public void AtualizarDuracao(int duracao)
        {
            Duracao = duracao;
        }
        public void AtualizarImagem(byte[] imagem)
        {
            Imagem = imagem;
        }
        public void AtualizarOrigem(string origem)
        {
            Origem = origem;
        }
        public void AtualizarDataLancamento(DateTime dataLancamento)
        {
            DataLancamento = dataLancamento;
        }
        public void AtualizarFaixaEtaria(int faixaEtaria)
        {
            FaixaEtaria = faixaEtaria;
        }
        public void AdicionarAvaliacao(AvaliacaoFilme avaliacao)
        {
            Avaliacoes?.Add(avaliacao);
        }
        public void RemoverAvaliacao(AvaliacaoFilme avaliacao)
        {
            Avaliacoes?.Remove(avaliacao);
        }
        #endregion
    }
}