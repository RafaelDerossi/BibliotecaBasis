using BibliotecaBasis.Aplicacao.Comandos.Assuntos.Commands;
using BibliotecaBasis.Dominio.Entidades;
using FluentValidation;

namespace BibliotecaBasis.Aplicacao.Comandos.Assuntos.Validacao
{
    public abstract class AssuntoValidation<T> : AbstractValidator<T> where T : AssuntoCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do assunto não pode estar vazio"); ;
        }
                
        protected void ValidateDescricao()
        {
            RuleFor(c => c.Descricao)
                .NotNull()
                    .WithMessage("Descrição do assunto não pode estar vazio")
                .NotEmpty()
                    .WithMessage("Descrição do assunto não pode estar vazio")
                .MaximumLength(Assunto.DescricaoSize)
                    .WithMessage($"Descrição do assunto deve ter até {Assunto.DescricaoSize} caracteres");
        }
    }
}
