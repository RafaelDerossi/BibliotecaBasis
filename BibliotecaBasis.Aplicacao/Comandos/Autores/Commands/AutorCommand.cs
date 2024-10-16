using BibliotecaBasis.Comum.Mensagens;

namespace BibliotecaBasis.Aplicacao.Comandos.Autores.Commands
{
    public abstract class AutorCommand : Command
    {
        public Guid Id { get; protected set; }

        public string? Nome { get; protected set; }
    }
}
