using BibliotecaBasis.Aplicacao.Comandos.Livros.Validacao;

namespace BibliotecaBasis.Aplicacao.Comandos.Livros.Commands
{
    public class ApagarPrecoCommand : PrecoCommand
    {
        public ApagarPrecoCommand(Guid id)
        {
            Id = id;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new ApagarPrecoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ApagarPrecoCommandValidation : PrecoValidation<ApagarPrecoCommand>
        {
            public ApagarPrecoCommandValidation()
            {
                ValidateId();
            }
        }
    }
}
