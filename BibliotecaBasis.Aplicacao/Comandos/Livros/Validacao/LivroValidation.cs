using BibliotecaBasis.Aplicacao.Comandos.Livros.Commands;
using BibliotecaBasis.Dominio.Entidades;
using FluentValidation;

namespace BibliotecaBasis.Aplicacao.Comandos.Livros.Validacao
{
    public abstract class LivroValidation<T> : AbstractValidator<T> where T : LivroCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do livro não pode estar vazio"); ;
        }

        protected void ValidateTitulo()
        {
            RuleFor(c => c.Titulo)
                .NotNull()
                    .WithMessage("Título do livro não pode estar vazio")
                .NotEmpty()
                    .WithMessage("Título do livro não pode estar vazio")
                .MaximumLength(Livro.TituloSize)
                    .WithMessage($"Título do livro deve ter até {Livro.TituloSize} caracteres");
        }

        protected void ValidateEditora()
        {
            RuleFor(c => c.Editora)                
                .MaximumLength(Livro.EditoraSize)
                    .WithMessage($"Editora do livro deve ter até {Livro.EditoraSize} caracteres");
        }

        protected void ValidateAnoPublicacao()
        {
            RuleFor(c => c.AnoPublicacao)                
                .Length(Livro.AnoPublicacaoSize)
                    .WithMessage($"Ano de Publicação do livro deve ter {Livro.AnoPublicacaoSize} caracteres");
        }
    }
}
