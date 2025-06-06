using MovieStar.Domain.Shared.Entities;

namespace MovieStar.Domain.Entities
{
    public abstract class Avaliacao : BaseEntity
    {
        public Guid UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }
        public string Comentario { get; private set; }
        public double Nota { get; private set; }
        public DateTime DataAvaliacao { get; private set; }
        protected Avaliacao() : base(Guid.NewGuid()) { }
        protected Avaliacao(Guid usuarioId, string comentario, double nota) : base(Guid.NewGuid())
        {
            UsuarioId = usuarioId;
            Comentario = comentario;
            Nota = nota;
            DataAvaliacao = DateTime.Now;
        }

        public void AtualizarComentario(string comentario)
        {
            Comentario = comentario;
        }
        public void AtualizarNota(double nota)
        {
            Nota = nota;
        }
        public void AtualizarDataAvaliacao()
        {
            DataAvaliacao = DateTime.Now;
        }
    }
}
