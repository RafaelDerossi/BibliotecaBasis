using BibliotecaBasis.Aplicacao.Comandos.Livros.Commands;
using BibliotecaBasis.Comum.Mediator.Mensagens;
using BibliotecaBasis.Dominio.Entidades;
using BibliotecaBasis.Dominio.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace BibliotecaBasis.Aplicacao.Comandos.Assuntos.Handlers
{
    public class PrecoCommandHandler
        (ILivroRepositorio livroRepositorio)
        : CommandHandler,
        IRequestHandler<AdicionarPrecoCommand, ValidationResult>,        
        IRequestHandler<ApagarPrecoCommand, ValidationResult>,
        IDisposable
    {
        private readonly ILivroRepositorio _livroRepositorio = livroRepositorio;       

        public async Task<ValidationResult> Handle(AdicionarPrecoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var preco = new Preco(request.LivroId, request.Valor, request.FormaDeVenda);

            _livroRepositorio.Adicionar(preco);

            return await PersistirDados(_livroRepositorio.UnitOfWork);
        }
        
        public async Task<ValidationResult> Handle(ApagarPrecoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var preco = await _livroRepositorio.ObterPrecoPorId(request.Id);
            if (preco is null)
            {
                AdicionarErro("Preço não encontrado");
                return ValidationResult;
            }

            preco.EnviarParaLixeira();

            _livroRepositorio.Atualizar(preco);

            return await PersistirDados(_livroRepositorio.UnitOfWork);
        }



        public void Dispose()
        {
            _livroRepositorio?.Dispose();
        }
    }
}
