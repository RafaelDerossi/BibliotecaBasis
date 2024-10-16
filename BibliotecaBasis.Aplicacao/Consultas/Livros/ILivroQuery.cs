using BibliotecaBasis.Dominio.Entidades;
using BibliotecaBasis.Dominio.Models.Livros;

namespace BibliotecaBasis.Aplicacao.Consultas.Livros
{
    public interface ILivroQuery : IDisposable
    {
        Task<Livro?> ObterPorId(Guid Id);

        Task<IEnumerable<Livro>?> ObterTodos();

        Task<IEnumerable<RelatorioLivroAutorResponseModel>?> ObterRelatorioDeLivros();
    }
}
