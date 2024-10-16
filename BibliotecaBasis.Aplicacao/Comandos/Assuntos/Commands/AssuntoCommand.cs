using BibliotecaBasis.Comum.Mediator.Mensagens;

namespace BibliotecaBasis.Aplicacao.Comandos.Assuntos.Commands
{
    public abstract class AssuntoCommand : Command
    {
        public Guid Id { get; protected set; }

        public string? Descricao { get; protected set; }
    }
}
