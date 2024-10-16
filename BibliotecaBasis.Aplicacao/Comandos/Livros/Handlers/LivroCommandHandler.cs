using BibliotecaBasis.Aplicacao.Comandos.Livros.Commands;
using BibliotecaBasis.Comum.Mediator.Mensagens;
using BibliotecaBasis.Dominio.Entidades;
using BibliotecaBasis.Dominio.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace BibliotecaBasis.Aplicacao.Comandos.Assuntos.Handlers
{
    public class LivroCommandHandler
        (ILivroRepositorio livroRepositorio, IAssuntoRepositorio assuntoRepositorio, IAutorRepositorio autorRepositorio)
        : CommandHandler,
        IRequestHandler<AdicionarLivroCommand, ValidationResult>,
        IRequestHandler<AtualizarLivroCommand, ValidationResult>,
        IRequestHandler<ApagarLivroCommand, ValidationResult>,
        IDisposable
    {
        private readonly ILivroRepositorio _livroRepositorio = livroRepositorio;
        private readonly IAssuntoRepositorio _assuntoRepositorio = assuntoRepositorio;
        private readonly IAutorRepositorio _autorRepositorio = autorRepositorio;

        public async Task<ValidationResult> Handle(AdicionarLivroCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var livro = new Livro(request.Titulo, request.Editora, request.Edicao, request.AnoPublicacao);

            
            var assuntos = await _assuntoRepositorio.Obter(a => request.Assuntos.Contains(a.Id)) ?? [];
            livro.SetAssuntos(assuntos);


            var autores = await _autorRepositorio.Obter(a => request.Autores.Contains(a.Id)) ?? [];
            livro.SetAutores(autores);


            _livroRepositorio.Adicionar(livro);

            return await PersistirDados(_livroRepositorio.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarLivroCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var livro = await _livroRepositorio.ObterPorId(request.Id);
            if (livro is null)
            {
                AdicionarErro("Livro não encontrado");
                return ValidationResult;
            }

            livro.SetTitulo(request.Titulo);
            livro.SetEditora(request.Editora);
            livro.SetEdicao(request.Edicao);
            livro.SetAnoPublicacao(request.AnoPublicacao);


            livro.ApagarAssuntos();
            var assuntos = await _assuntoRepositorio.Obter(a => request.Assuntos.Contains(a.Id)) ?? [];
            livro.SetAssuntos(assuntos);

            livro.ApagarAutores();
            var autores = await _autorRepositorio.Obter(a => request.Autores.Contains(a.Id)) ?? [];
            livro.SetAutores(autores);

            _livroRepositorio.Atualizar(livro);

            return await PersistirDados(_livroRepositorio.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ApagarLivroCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var livro = await _livroRepositorio.ObterPorId(request.Id);
            if (livro is null)
            {
                AdicionarErro("Livro não encontrado");
                return ValidationResult;
            }

            livro.EnviarParaLixeira();

            _livroRepositorio.Atualizar(livro);

            return await PersistirDados(_livroRepositorio.UnitOfWork);
        }



        public void Dispose()
        {
            _livroRepositorio?.Dispose();
        }
    }
}
