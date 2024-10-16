using BibliotecaBasis.Aplicacao.Comandos.Livros.Validacao;
using BibliotecaBasis.Dominio.Models.Livros;

namespace BibliotecaBasis.Aplicacao.Comandos.Livros.Commands
{
    public class AdicionarLivroCommand : LivroCommand
    {
        public AdicionarLivroCommand(AdicionaLivroRequestModel model)
        {
            Titulo = model.Titulo;
            Editora = model.Editora;
            Edicao = model.Edicao;
            AnoPublicacao = model.AnoPublicacao;
            Autores = model.Autores ?? [];
            Assuntos = model.Assuntos ?? [];
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarLivroCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarLivroCommandValidation : LivroValidation<AdicionarLivroCommand>
        {
            public AdicionarLivroCommandValidation()
            {
                ValidateTitulo();
                ValidateEditora();
                ValidateAnoPublicacao();
            }
        }
    }
}
