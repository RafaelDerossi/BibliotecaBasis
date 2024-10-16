namespace BibliotecaBasis.Dominio.Models.Livros
{
    public class AdicionaLivroRequestModel
    {
        public string? Titulo { get; set; }

        public string? Editora { get; set; }

        public int Edicao { get; set; }

        public string? AnoPublicacao { get; set; }

        public IEnumerable<Guid>? Autores { get; set; }

        public IEnumerable<Guid>? Assuntos { get; set; }

    }
}
