using BibliotecaBasis.Dominio.Interfaces;
using BibliotecaBasis.Dominio.Entidades;

namespace BibliotecaBasis.Aplicacao.Consultas.Livros
{
    public class LivroQuery(ILivroRepositorio livroRepositorio) : ILivroQuery
    {
        private readonly ILivroRepositorio _livroRepositorio = livroRepositorio;

        public async Task<Livro?> ObterPorId(Guid Id)
        {
            return await _livroRepositorio.ObterPorId(Id);
        }

        public async Task<IEnumerable<Livro>?> ObterTodos()
        {
            return await _livroRepositorio.Obter(l=>!l.Lixeira);
        }



        public void Dispose()
        {
            _livroRepositorio.Dispose();
        }
    }
}
