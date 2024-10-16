using BibliotecaBasis.Dominio.Entidades;
using BibliotecaBasis.Dominio.Models.Livros;

namespace BibliotecaBasis.Dominio.Models.Autores
{
    public class AutorComLivrosResponseModel
    {
        public Guid Id { get; set; }

        public string? Nome { get; set; }

        public IEnumerable<LivroSemIncludesResponseModel>? Livros { get; set; }


        public static AutorComLivrosResponseModel Mapear(Autor autor)
        {
            return new AutorComLivrosResponseModel
            {
                Id = autor.Id,
                Nome = autor.Nome,
                Livros = autor.Livros.Select(LivroSemIncludesResponseModel.Mapear)
            };
        }
    }
}
