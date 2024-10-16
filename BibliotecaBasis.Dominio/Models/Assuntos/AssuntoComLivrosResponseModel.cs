using BibliotecaBasis.Dominio.Entidades;
using BibliotecaBasis.Dominio.Models.Livros;

namespace BibliotecaBasis.Dominio.Models.Assuntos
{
    public class AssuntoComLivrosResponseModel
    {
        public Guid Id { get; set; }

        public string? Descricao { get; set; }

        public IEnumerable<LivroSemIncludesResponseModel>? Livros { get; set; }


        public static AssuntoComLivrosResponseModel Mapear(Assunto assunto)
        {
            return new AssuntoComLivrosResponseModel
            {
                Id = assunto.Id,
                Descricao = assunto.Descricao,
                Livros = assunto.Livros.Select(LivroSemIncludesResponseModel.Mapear)
            };
        }
    }
}
