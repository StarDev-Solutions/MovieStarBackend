namespace MovieStar.Domain.Entities
{
    public sealed class AvaliacaoSerie : Avaliacao
    {
        #region Propriedades
        public Guid SerieId { get; private set; }
        public Serie Serie { get; private set; }
        #endregion

        #region Construtor
        private AvaliacaoSerie() : base() { }

        public AvaliacaoSerie(Guid usuarioId, Guid serieId, string comentario, double nota) : base(usuarioId, comentario, nota)
        {
            SerieId = serieId;
        }
        #endregion
    }
}