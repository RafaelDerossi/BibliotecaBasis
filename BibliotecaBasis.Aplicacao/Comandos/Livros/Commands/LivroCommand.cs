using BibliotecaBasis.Comum.Mensagens;

namespace BibliotecaBasis.Aplicacao.Comandos.Livros.Commands
{
    public abstract class LivroCommand : Command
    {
        public Guid Id { get; protected set; }

        public string? Titulo { get; protected set; }

        public string? Editora { get; protected set; }

        public int Edicao { get; protected set; }

        public string? AnoPublicacao { get; protected set; }

    }
}
