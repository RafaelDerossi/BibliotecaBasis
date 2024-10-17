using BibliotecaBasis.Dominio.Models.Autores;

namespace BibliotecaBasis.Dominio.Models.Livros
{
    public class RelatorioLivroAutorResponseModel
    {
        public AutorResponseModel? Autor { get; set; }

        public List<LivroAutorResponseModel>? Livros { get; set; }

        public RelatorioLivroAutorResponseModel()
        {
            Livros = [];
        }

        public void SetAutor(Guid? id, string? nome)
        {
            Autor = new AutorResponseModel { Id = id, Nome = nome };
        }

        public void AdicionarLivro
            (Guid? id, string? titulo, string? editora, int? edicao,
             string? anoPublicacao, string? assuntos, string? autores)
        {
            Livros?.Add(new LivroAutorResponseModel
                (id, titulo, editora, edicao, anoPublicacao, assuntos, autores));
        }

    }
        

    public class LivroAutorResponseModel
    {
        public Guid? Id { get; set; }

        public string? Titulo { get; set; }

        public string? Editora { get; set; }

        public int? Edicao { get; set; }

        public string? AnoPublicacao { get; set; }


        public Guid? AutorId { get; set; }
        public string? AutorNome { get; set; }

        public string? Assuntos { get; set; }

        public string? Autores { get; set; }


        public LivroAutorResponseModel()
        {
        }

        public LivroAutorResponseModel
            (Guid? id, string? titulo, string? editora, int? edicao,
             string? anoPublicacao, string? assuntos, string? autores)
        {
            Id = id;            
            Titulo = titulo;
            Editora = editora;
            Edicao = edicao;
            AnoPublicacao = anoPublicacao;            
            Assuntos = assuntos;
            Autores = autores;
        }
    }
}
