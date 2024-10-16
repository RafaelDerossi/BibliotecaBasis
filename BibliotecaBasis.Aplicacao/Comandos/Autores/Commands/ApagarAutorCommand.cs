using BibliotecaBasis.Aplicacao.Comandos.Autores.Validacao;

namespace BibliotecaBasis.Aplicacao.Comandos.Autores.Commands
{
    public class ApagarAutorCommand : AutorCommand
    {
        public ApagarAutorCommand(Guid id)
        {
            Id = id;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new ApagarAutorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ApagarAutorCommandValidation : AutorValidation<ApagarAutorCommand>
        {
            public ApagarAutorCommandValidation()
            {
                ValidateId();
            }
        }
    }
}
