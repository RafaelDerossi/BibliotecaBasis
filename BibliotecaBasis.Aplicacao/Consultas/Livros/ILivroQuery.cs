using BibliotecaBasis.Dominio.Entidades;

namespace BibliotecaBasis.Aplicacao.Consultas.Livros
{
    public interface ILivroQuery : IDisposable
    {
        Task<Livro?> ObterPorId(Guid Id);

        Task<IEnumerable<Livro>?> ObterTodos();
    }
}
