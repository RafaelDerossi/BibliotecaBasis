using BibliotecaBasis.Dominio.Entidades;

namespace BibliotecaBasis.Aplicacao.Consultas.Assuntos
{
    public interface IAssuntoQuery : IDisposable
    {
        Task<Assunto?> ObterPorId(Guid Id);

        Task<IEnumerable<Assunto>?> ObterTodos();
    }
}
