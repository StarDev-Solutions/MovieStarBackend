using MovieStar.Domain.Shared.Entities;

namespace MovieStar.Domain.Entities
{
    public class Genero : BaseEntity
    {
        public string Nome { get; private set; }
        public Genero(): base(Guid.NewGuid()) {}
        public Genero(string nome) : base(Guid.NewGuid())
        {
            Nome = nome;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }
    }
}