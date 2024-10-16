using BibliotecaBasis.Dominio.Entidades;
using BibliotecaBasis.Dominio.Models.Assuntos;
using BibliotecaBasis.Dominio.Models.Autores;
using BibliotecaBasis.Dominio.Models.Precos;

namespace BibliotecaBasis.Dominio.Models.Livros
{
    public class LivroResponseModel
    {
        public Guid Id { get; set; }

        public string? Titulo { get; set; }

        public string? Editora { get; set; }

        public int Edicao { get; set; }

        public string? AnoPublicacao { get; set; }

        public IEnumerable<AutorResponseModel>? Autores { get; set; }

        public IEnumerable<AssuntoResponseModel>? Assuntos { get; set; }

        public IEnumerable<PrecoResponseModel>? Precos { get; set; }

        public static LivroResponseModel Mapear(Livro livro)
        {
            return new LivroResponseModel
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                Editora = livro.Editora,
                Edicao = livro.Edicao,
                AnoPublicacao = livro.AnoPublicacao,
                Autores = livro.Autores?.Select(AutorResponseModel.Mapear),
                Assuntos = livro.Assuntos?.Select(AssuntoResponseModel.Mapear),
                Precos = livro.Precos?.Select(PrecoResponseModel.Mapear)
            };
        }

    }
}
