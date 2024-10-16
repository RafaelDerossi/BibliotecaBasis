using BibliotecaBasis.Comum.ObjetosDeInfra;
using BibliotecaBasis.Dominio.Entidades;
using BibliotecaBasis.Dominio.Models.Livros;

namespace BibliotecaBasis.Dominio.Interfaces
{
    public interface ILivroRepositorio : IRepository<Livro>
    {
        Task<IEnumerable<LivroViewModel>?> ObterViewDeLivros();


        Task<Preco?> ObterPrecoPorId(Guid Id);

        void Adicionar(Preco entity);

        void Atualizar(Preco entity);
    }
}
