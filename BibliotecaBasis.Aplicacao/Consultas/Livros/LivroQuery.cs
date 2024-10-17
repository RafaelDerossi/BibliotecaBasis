using BibliotecaBasis.Dominio.Interfaces;
using BibliotecaBasis.Dominio.Entidades;
using BibliotecaBasis.Dominio.Models.Livros;
using BibliotecaBasis.Dominio.DTOs.Livros;

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

            var relatorioPrecessado = ProcesarRelatorioDeLivroPorAutor(livros);
            
            var agrupados = relatorioPrecessado.GroupBy(x => x.AutorId);            

            foreach (var autorAgrupado in agrupados)
            {
                var item = new RelatorioLivroAutorResponseModel();

                item.SetAutor(autorAgrupado.Key, autorAgrupado.FirstOrDefault()?.AutorNome);               
                                    
                foreach (var livro in autorAgrupado)
                {
                    item.AdicionarLivro
                        (livro?.Id, livro?.Titulo, livro?.Editora, livro?.Edicao, 
                         livro?.AnoPublicacao, livro?.Assuntos, livro?.Autores);                    
                }

                resposta.Add(item);
            }

            return resposta.OrderBy(x=>x.Autor?.Nome);
        }

        private IEnumerable<LivroRelatorioDTO> ProcesarRelatorioDeLivroPorAutor(IEnumerable<LivroViewModel> livros)
        {
            var resposta = new List<LivroRelatorioDTO>();

            var livrosAgrupados = livros.GroupBy(x => x.Id);

            foreach (var livroAgrupado in livrosAgrupados)
            {
                var livroAgrupadoPorAssunto = livroAgrupado.GroupBy(x => x.AssuntoId);

                var autoresDoLivro = livroAgrupadoPorAssunto.Select(l => l.Select(a => a.AutorNome)).FirstOrDefault();
                var autores = string.Join(";", autoresDoLivro!);


                var livroAgrupadoPorAutores = livroAgrupado.GroupBy(x => x.AutorId);

                var assuntosDoLivro = livroAgrupadoPorAutores.Select(l => l.Select(a => a.AssuntoDescricao)).FirstOrDefault();
                var assuntos = string.Join(";", assuntosDoLivro!);

                foreach (var livroPorAutor in livroAgrupadoPorAutores)
                {
                    var livro = livroPorAutor.FirstOrDefault();

                    var model = new LivroRelatorioDTO
                        (livro?.Id, livro?.DataDeCadastro, livro?.DataDeAlteracao, livro?.Titulo,
                         livro?.Editora, livro?.Edicao, livro?.AnoPublicacao, livro?.AutorId, livro?.AutorNome,
                         assuntos, autores);

                    resposta.Add(model);
                }

            }

            return resposta;
        }

        public void Dispose()
        {
            _livroRepositorio.Dispose();
        }
    }
}
