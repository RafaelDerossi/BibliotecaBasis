namespace BibliotecaBasis.Dominio.Models.Livros
{
    public class RelatorioLivroAutorResponseModel
    {
        public Guid? Id { get; set; }

        public DateTime? DataDeCadastro { get; set; }

        public DateTime? DataDeAlteracao { get; set; }       


        public string? Titulo { get; set; }

        public string? Editora { get; set; }

        public int? Edicao { get; set; }

        public string? AnoPublicacao { get; set; }


        public Guid? AutorId { get; set; }
        public string? AutorNome { get; set; }
        
        public string? Assuntos { get; set; }

        public string? Autores { get; set; }


        public RelatorioLivroAutorResponseModel()
        {                
        }

        public RelatorioLivroAutorResponseModel
            (Guid? id, DateTime? dataDeCadastro, DateTime? dataDeAlteracao, string? titulo,
            string? editora, int? edicao, string? anoPublicacao, Guid? autorId, string? autorNome,
            string? assuntos, string? autores)
        {
            Id = id;
            DataDeCadastro = dataDeCadastro;
            DataDeAlteracao = dataDeAlteracao;
            Titulo = titulo;
            Editora = editora;
            Edicao = edicao;
            AnoPublicacao = anoPublicacao;
            AutorId = autorId;
            AutorNome = autorNome;
            Assuntos = assuntos;
            Autores = autores;
        }
    }
}
