using BibliotecaBasis.Dominio.Entidades;
using BibliotecaBasis.Dominio.ViewModels.Livros;

namespace BibliotecaBasis.Dominio.ViewModels.Assuntos
{
    public class AssuntoComLivrosViewModel
    {
        public Guid Id { get; set; }

        public string? Descricao { get; set; }

        public IEnumerable<LivroSemIncludesViewModel>? Livros { get; set; }


        public static AssuntoComLivrosViewModel Mapear(Assunto assunto)
        {  
            return new AssuntoComLivrosViewModel
            { 
                Id = assunto.Id,
                Descricao = assunto.Descricao,
                Livros = assunto.Livros.Select(LivroSemIncludesViewModel.Mapear)
            }; 
        }
    }
}
