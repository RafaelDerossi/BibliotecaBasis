using BibliotecaBasis.Dominio.Entidades;

namespace BibliotecaBasis.Dominio.ViewModels.Livros
{
    public class LivroSemIncludesViewModel
    {
        public Guid Id { get; set; }

        public string? Titulo { get; set; }

        public string? Editora { get; set; }

        public int Edicao { get; set; }

        public string? AnoPublicacao { get; set; }        


        public static LivroSemIncludesViewModel Mapear(Livro livro)
        {
            return new LivroSemIncludesViewModel
            { 
                Id = livro.Id,
                Titulo = livro.Titulo,
                Editora = livro.Editora,
                Edicao = livro.Edicao,
                AnoPublicacao = livro.AnoPublicacao                
            };
        }

    }
}
