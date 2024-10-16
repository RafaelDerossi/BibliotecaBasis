using BibliotecaBasis.Aplicacao.Comandos.Livros.Commands;
using FluentValidation;

namespace BibliotecaBasis.Aplicacao.Comandos.Livros.Validacao
{
    public abstract class PrecoValidation<T> : AbstractValidator<T> where T : PrecoCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do preço não pode estar vazio"); ;
        }

        protected void ValidateLivroId()
        {
            RuleFor(c => c.LivroId)
                .NotEqual(Guid.Empty)
                .WithMessage("LivroId não pode estar vazio"); ;
        }

        protected void ValidateValor()
        {
            RuleFor(c => c.Valor)
                .NotNull()
                    .WithMessage("Valor do livro não pode estar vazio");
        }

        protected void ValidateFormaDeVenda()
        {
            RuleFor(c => c.FormaDeVenda)
                .IsInEnum()
                    .WithMessage("Forma de venda inválida");
        }
    }
}
