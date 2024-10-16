using BibliotecaBasis.Aplicacao.Comandos.Autores.Commands;
using BibliotecaBasis.Comum.Mediator.Mensagens;
using BibliotecaBasis.Dominio.Entidades;
using BibliotecaBasis.Dominio.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace BibliotecaBasis.Aplicacao.Comandos.Assuntos.Handlers
{
    public class AutorCommandHandler(IAutorRepositorio autorRepositorio) : CommandHandler,
        IRequestHandler<AdicionarAutorCommand, ValidationResult>,
         IDisposable
    {
        private readonly IAutorRepositorio autorRepositorio = autorRepositorio;

        public async Task<ValidationResult> Handle(AdicionarAutorCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            autorRepositorio.Adicionar(new Autor(request.Nome));            

            return await PersistirDados(autorRepositorio.UnitOfWork);
        }


        public void Dispose()
        {
            autorRepositorio?.Dispose();
        }
    }
}
