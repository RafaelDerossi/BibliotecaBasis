namespace BibliotecaBasis.Dominio.Models.Livros
{
    public class LivroViewModel
    {
        public Guid Id { get; set; }

        public DateTime DataDeCadastro { get; set; }

        public DateTime DataDeAlteracao { get; set; }

        public bool Lixeira { get; set; }


        public string? Titulo { get; set; }

        public string? Editora { get; set; }

        public int Edicao { get; set; }

        public string? AnoPublicacao { get; set; }


        public Guid AutorId { get; set; }
        public string? AutorNome { get; set; }


        public Guid AssuntoId { get; set; }
        public string? AssuntoDescricao { get; set; }

    }
}
