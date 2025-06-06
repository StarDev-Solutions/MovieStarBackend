namespace MovieStar.Domain.Entities
{
    public sealed class AvaliacaoFilme : Avaliacao
    {
        public Guid FilmeId { get; private set; }
        public Filme Filme { get; private set; }

        private AvaliacaoFilme() : base() { }

        public AvaliacaoFilme(Guid usuarioId, Guid filmeId, string comentario, double nota)
            : base(usuarioId, comentario, nota)
        {
            FilmeId = filmeId;
        }
    }

}