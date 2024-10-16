using BibliotecaBasis.Aplicacao.Comandos.Assuntos.Validacao;

namespace BibliotecaBasis.Aplicacao.Comandos.Assuntos.Commands
{
    public class ApagarAssuntoCommand : AssuntoCommand
    {
        public ApagarAssuntoCommand(Guid id)
        {
            Id = id;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new ApagarAssuntoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ApagarAssuntoCommandValidation : AssuntoValidation<ApagarAssuntoCommand>
        {
            public ApagarAssuntoCommandValidation()
            {
                ValidateId();
            }
        }
    }
}
