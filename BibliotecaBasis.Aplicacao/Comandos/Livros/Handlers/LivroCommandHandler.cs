using BibliotecaBasis.Aplicacao.Comandos.Livros.Commands;
using BibliotecaBasis.Comum.Mediator.Mensagens;
using BibliotecaBasis.Dominio.Entidades;
using BibliotecaBasis.Dominio.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace BibliotecaBasis.Aplicacao.Comandos.Assuntos.Handlers
{
    public class LivroCommandHandler(ILivroRepositorio livroRepositorio) : CommandHandler,
        IRequestHandler<AdicionarLivroCommand, ValidationResult>,
         IDisposable
    {
        private readonly ILivroRepositorio _livroRepositorio = livroRepositorio;

        public async Task<ValidationResult> Handle(AdicionarLivroCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            _livroRepositorio.Adicionar
                (new Livro(request.Titulo, request.Editora, request.Edicao, request.AnoPublicacao));

            return await PersistirDados(_livroRepositorio.UnitOfWork);
        }


        public void Dispose()
        {
            _livroRepositorio?.Dispose();
        }
    }
}
