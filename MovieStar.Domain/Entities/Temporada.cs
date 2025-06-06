using MovieStar.Domain.Shared.Entities;

namespace MovieStar.Domain.Entities
{
    public sealed class Temporada : BaseEntity
    {
        #region Propriedades
        public int Numero { get; private set; }
        public DateTime DataLancamento { get; private set; }
        public List<Episodio> Episodio { get; private set; }
        public Guid SerieId { get; private set; }
        public Serie Serie { get; private set; }

        #endregion

        #region Construtor
        private Temporada() : base(Guid.NewGuid()) { }

        public Temporada(int numero, DateTime dataLancamento, List<Episodio> episodio, Guid serieId, Serie serie) : base(Guid.NewGuid())
        {
            Numero = numero;
            DataLancamento = dataLancamento;
            Episodio = episodio;
            SerieId = serieId;
            Serie = serie;
        }
        #endregion

        #region Métodos
        public void AdicionarEpisodio(Episodio episodio)
        {
            Episodio.Add(episodio);
        }
        #endregion
    }
}