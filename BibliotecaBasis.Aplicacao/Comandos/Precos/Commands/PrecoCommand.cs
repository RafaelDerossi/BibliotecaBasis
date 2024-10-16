using BibliotecaBasis.Comum.Enumeradores;
using BibliotecaBasis.Comum.Mediator.Mensagens;

namespace BibliotecaBasis.Aplicacao.Comandos.Livros.Commands
{
    public abstract class PrecoCommand : Command
    {
        public Guid Id { get; protected set; }

        public Guid LivroId { get; protected set; }

        public decimal Valor { get; protected set; }

        public FormaDeVenda FormaDeVenda { get; protected set; }
        
    }
}
