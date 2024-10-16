using BibliotecaBasis.Comum.ObjetosDeDominio;

namespace BibliotecaBasis.Dominio.Entidades
{
    public class Autor(string? nome) : Entidade, IAggregateRoot
    {
        public const int NomeSize = 40;

        public string? Nome { get; set; } = nome;


        private readonly List<Livro> _Livros = [];
        public IReadOnlyCollection<Livro> Livros => _Livros;


        public void SetNome(string? valor) => Nome = valor;
    }
}
