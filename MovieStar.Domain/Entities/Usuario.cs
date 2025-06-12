using MovieStar.Domain.Shared.Entities;

namespace MovieStar.Domain.Entities
{
    public sealed class Usuario : BaseEntity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public List<AvaliacaoFilme>? AvaliacoesFilme { get; private set; }
        public List<AvaliacaoSerie>? AvaliacoesSerie { get; private set; }
        public bool Assinante{ get; private set; }
        public string Role { get; private set; }
        public byte[]? Imagem { get; private set; }

        private Usuario() : base(Guid.NewGuid()) { }

        public Usuario(string nome, string email, string senha, 
            List<AvaliacaoFilme>? avaliacaoFilme, List<AvaliacaoSerie>? avaliacaoSeries,bool assinante, string role, byte[]? imagem) : base(Guid.NewGuid())
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            AvaliacoesFilme = avaliacaoFilme ?? new List<AvaliacaoFilme>();
            AvaliacoesSerie = avaliacaoSeries ?? new List<AvaliacaoSerie>();
            Assinante = assinante;
            Role = role;
            Imagem = imagem ?? Array.Empty<byte>();
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }
        public void AlterarEmail(string email)
        {
            Email = email;
        }
        public void AtualizarSenha(string senha)
        {
            Senha = senha;
        }
        public void AlterarAssinante(bool assinante)
        {
            Assinante = assinante;
        }
        public void AlterarRole(string role)
        {
            Role = role;
        }
        public void AlterarImagem(byte[] imagem)
        {
            Imagem = imagem;
        }
    }
}