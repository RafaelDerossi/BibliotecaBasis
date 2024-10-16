using BibliotecaBasis.Dominio.Entidades;

namespace BibliotecaBasis.Dominio.Models.Livros
{
    public class LivroSemIncludesResponseModel
    {
        public Guid Id { get; set; }

        public string? Titulo { get; set; }

        public string? Editora { get; set; }

        public int Edicao { get; set; }

        public string? AnoPublicacao { get; set; }


        public static LivroSemIncludesResponseModel Mapear(Livro livro)
        {
            return new LivroSemIncludesResponseModel
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
