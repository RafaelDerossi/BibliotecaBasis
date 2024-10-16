using BibliotecaBasis.Aplicacao.Comandos.Autores.Commands;
using BibliotecaBasis.Dominio.Entidades;
using FluentValidation;

namespace BibliotecaBasis.Aplicacao.Comandos.Autores.Validacao
{
    public abstract class AutorValidation<T> : AbstractValidator<T> where T : AutorCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do autor não pode estar vazio"); ;
        }

        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotNull()
                    .WithMessage("Nome do autor não pode estar vazio")
                .NotEmpty()
                    .WithMessage("Nome do autor não pode estar vazio")
                .MaximumLength(Autor.NomeSize)
                    .WithMessage($"Nome do autor deve ter até {Autor.NomeSize} caracteres");
        }
    }
}
