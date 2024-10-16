using BibliotecaBasis.Dominio.Entidades;
using BibliotecaBasis.Dominio.ViewModels.Assuntos;
using BibliotecaBasis.Dominio.ViewModels.Autores;

namespace BibliotecaBasis.Dominio.ViewModels.Livros
{
    public class LivroViewModel
    {
        public Guid Id { get; set; }

        public string? Titulo { get; set; }

        public string? Editora { get; set; }

        public int Edicao { get; set; }

        public string? AnoPublicacao { get; set; }

        public IEnumerable<AutorViewModel>? Autores { get; set; }

        public IEnumerable<AssuntoViewModel>? Assuntos { get; set; }

        public IEnumerable<PrecoViewModel>? Precos { get; set; }

        public static LivroViewModel Mapear(Livro livro)
        {
            return new LivroViewModel 
            { 
                Id = livro.Id,
                Titulo = livro.Titulo,
                Editora = livro.Editora,
                Edicao = livro.Edicao,
                AnoPublicacao = livro.AnoPublicacao,
                Autores = livro.Autores?.Select(AutorViewModel.Mapear),
                Assuntos = livro.Assuntos?.Select(AssuntoViewModel.Mapear),
                Precos = livro.Precos?.Select(PrecoViewModel.Mapear)
            };
        }

    }
}
