using BibliotecaBasis.Comum.ObjetosDeDominio;

namespace BibliotecaBasis.Dominio.Entidades
{
    public class Assunto(string? descricao) : Entidade, IAggregateRoot
    {
        public const int DescricaoSize = 20;

        public string? Descricao { get; private set; } = descricao;


        private readonly List<Livro> _Livros = [];
        public IReadOnlyCollection<Livro> Livros => _Livros;


        public void SetDescricao(string? valor) => Descricao = valor;
    }
}
