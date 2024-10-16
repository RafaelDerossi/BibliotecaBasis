using BibliotecaBasis.Dominio.Interfaces;
using BibliotecaBasis.Dominio.Entidades;
using BibliotecaBasis.Dominio.Models.Livros;

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

        public async Task<IEnumerable<RelatorioLivroAutorResponseModel>?> ObterRelatorioDeLivros()
        {
            var resposta = new List<RelatorioLivroAutorResponseModel>();

            var livros = await _livroRepositorio.ObterViewDeLivros();
            if (livros == null)
                return resposta;

            var livrosAgrupados = livros.GroupBy(x => x.Id);

            foreach (var livroAgrupado in livrosAgrupados)
            {
                var livroAgrupadoPorAssunto = livroAgrupado.GroupBy(x => x.AssuntoId);

                var autoresDoLivro = livroAgrupadoPorAssunto.Select(l => l.Select(a => a.AutorNome)).FirstOrDefault();
                var autores = string.Join(";", autoresDoLivro!);


                var livroAgrupadoPorAutores = livroAgrupado.GroupBy(x => x.AutorId);

                var assuntosDoLivro = livroAgrupadoPorAutores.Select(l => l.Select(a=>a.AssuntoDescricao)).FirstOrDefault();                
                var assuntos = string.Join(";", assuntosDoLivro!);

                foreach (var livroPorAutor in livroAgrupadoPorAutores)
                {
                    var livro = livroPorAutor.FirstOrDefault();

                    var model = new RelatorioLivroAutorResponseModel
                        (livro?.Id, livro?.DataDeCadastro, livro?.DataDeAlteracao, livro?.Titulo,
                         livro.Editora, livro.Edicao, livro.AnoPublicacao, livro.AutorId, livro.AutorNome,
                         assuntos, autores);

                    resposta.Add(model);
                }
                    
            }

            return resposta.OrderBy(x=>x.AutorNome);
        }

        public void Dispose()
        {
            _livroRepositorio.Dispose();
        }
    }
}
