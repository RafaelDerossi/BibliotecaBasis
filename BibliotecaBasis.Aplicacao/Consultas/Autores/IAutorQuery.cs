using BibliotecaBasis.Dominio.Entidades;

namespace BibliotecaBasis.Aplicacao.Consultas.Autores
{
    public interface IAutorQuery : IDisposable
    {
        Task<Autor?> ObterPorId(Guid Id);

        Task<IEnumerable<Autor>?> ObterTodos();
    }
}
