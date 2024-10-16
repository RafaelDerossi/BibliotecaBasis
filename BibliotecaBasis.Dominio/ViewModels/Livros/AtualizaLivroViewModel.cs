using BibliotecaBasis.Dominio.ViewModels.Assuntos;
using BibliotecaBasis.Dominio.ViewModels.Autores;

namespace BibliotecaBasis.Dominio.ViewModels.Livros
{
    public class AtualizaLivroViewModel
    {
        public Guid Id { get; set; }

        public string? Titulo { get; set; }

        public string? Editora { get; set; }

        public int Edicao { get; set; }

        public string? AnoPublicacao { get; set; }

        public IEnumerable<Guid>? Autores { get; set; }

        public IEnumerable<Guid>? Assuntos { get; set; }
        
    }
}
