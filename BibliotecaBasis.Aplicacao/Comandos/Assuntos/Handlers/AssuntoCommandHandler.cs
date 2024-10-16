using BibliotecaBasis.Aplicacao.Comandos.Assuntos.Commands;
using BibliotecaBasis.Comum.Mediator.Mensagens;
using BibliotecaBasis.Dominio.Entidades;
using BibliotecaBasis.Dominio.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace BibliotecaBasis.Aplicacao.Comandos.Assuntos.Handlers
{
    public class AssuntoCommandHandler(IAssuntoRepositorio assuntoRepositorio) : CommandHandler, 
        IRequestHandler<AdicionarAssuntoCommand, ValidationResult>,
        IRequestHandler<AtualizarAssuntoCommand, ValidationResult>,
        IRequestHandler<ApagarAssuntoCommand, ValidationResult>,
        IDisposable
    {
        private readonly IAssuntoRepositorio _assuntoRepositorio = assuntoRepositorio;

        public async Task<ValidationResult> Handle(AdicionarAssuntoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            _assuntoRepositorio.Adicionar(new Assunto(request.Descricao));            

            return await PersistirDados(_assuntoRepositorio.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarAssuntoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var assunto = await _assuntoRepositorio.ObterPorId(request.Id);
            if (assunto is null)
            {
                AdicionarErro("Assunto não encontrado");
                return ValidationResult;
            }

            assunto.SetDescricao(request.Descricao);

            _assuntoRepositorio.Atualizar(assunto);

            return await PersistirDados(_assuntoRepositorio.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ApagarAssuntoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var assunto = await _assuntoRepositorio.ObterPorId(request.Id);
            if (assunto is null)
            {
                AdicionarErro("Assunto não encontrado");
                return ValidationResult;
            }

            assunto.EnviarParaLixeira();

            _assuntoRepositorio.Atualizar(assunto);

            return await PersistirDados(_assuntoRepositorio.UnitOfWork);
        }


        public void Dispose()
        {
            _assuntoRepositorio?.Dispose();
        }
    }
}
