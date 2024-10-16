using BibliotecaBasis.Aplicacao.Comandos.Livros.Validacao;

namespace BibliotecaBasis.Aplicacao.Comandos.Livros.Commands
{
    public class ApagarLivroCommand : LivroCommand
    {
        public ApagarLivroCommand(Guid id)
        {
            Id = id;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new ApagarLivroCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ApagarLivroCommandValidation : LivroValidation<ApagarLivroCommand>
        {
            public ApagarLivroCommandValidation()
            {
                ValidateId();
            }
        }
    }
}
