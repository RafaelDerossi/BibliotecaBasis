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
        IRequestHandler<AtualizarAutorCommand, ValidationResult>,
        IRequestHandler<ApagarAutorCommand, ValidationResult>,
        IDisposable
    {
        private readonly IAutorRepositorio _autorRepositorio = autorRepositorio;

        public async Task<ValidationResult> Handle(AdicionarAutorCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            _autorRepositorio.Adicionar(new Autor(request.Nome));            

            return await PersistirDados(_autorRepositorio.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarAutorCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var autor = await _autorRepositorio.ObterPorId(request.Id);
            if (autor is null)
            {
                AdicionarErro("Autor não encontrado");
                return ValidationResult;
            }

            autor.SetNome(request.Nome);

            _autorRepositorio.Atualizar(autor);

            return await PersistirDados(_autorRepositorio.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ApagarAutorCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var autor = await _autorRepositorio.ObterPorId(request.Id);
            if (autor is null)
            {
                AdicionarErro("Autor não encontrado");
                return ValidationResult;
            }

            autor.EnviarParaLixeira();

            _autorRepositorio.Atualizar(autor);

            return await PersistirDados(_autorRepositorio.UnitOfWork);
        }


        public void Dispose()
        {
            _autorRepositorio?.Dispose();
        }
    }
}
