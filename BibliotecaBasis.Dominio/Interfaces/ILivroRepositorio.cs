using BibliotecaBasis.Comum.ObjetosDeInfra;
using BibliotecaBasis.Dominio.Entidades;

namespace BibliotecaBasis.Dominio.Interfaces
{
    public interface ILivroRepositorio : IRepository<Livro>
    {
        Task<Preco?> ObterPrecoPorId(Guid Id);

        void Adicionar(Preco entity);

        void Atualizar(Preco entity);
    }
}
