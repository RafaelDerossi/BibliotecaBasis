using BibliotecaBasis.Dominio.Entidades;
using BibliotecaBasis.Dominio.ViewModels.Livros;

namespace BibliotecaBasis.Dominio.ViewModels.Autores
{
    public class AutorComLivrosViewModel
    {
        public Guid Id { get; set; }

        public string? Nome { get; set; }

        public IEnumerable<LivroSemIncludesViewModel>? Livros { get; set; }


        public static AutorComLivrosViewModel Mapear(Autor autor)
        {
            return new AutorComLivrosViewModel
            { 
                Id = autor.Id,
                Nome = autor.Nome ,
                Livros = autor.Livros.Select(LivroSemIncludesViewModel.Mapear)
            };
        }
    }
}
