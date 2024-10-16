using BibliotecaBasis.Aplicacao.Comandos.Livros.Validacao;
using BibliotecaBasis.Dominio.Models.Livros;

namespace BibliotecaBasis.Aplicacao.Comandos.Livros.Commands
{
    public class AtualizarLivroCommand : LivroCommand
    {
        public AtualizarLivroCommand(AtualizaRequestModel model)
        {
            Id = model.Id;
            Titulo = model.Titulo;
            Editora = model.Editora;
            Edicao = model.Edicao;
            AnoPublicacao = model.AnoPublicacao;
            Assuntos = model.Assuntos ?? [];
            Autores = model.Autores ?? [];
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtualizarLivroCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtualizarLivroCommandValidation : LivroValidation<AtualizarLivroCommand>
        {
            public AtualizarLivroCommandValidation()
            {
                ValidateId();
                ValidateTitulo();
                ValidateEditora();
                ValidateAnoPublicacao();
            }
        }
    }
}
