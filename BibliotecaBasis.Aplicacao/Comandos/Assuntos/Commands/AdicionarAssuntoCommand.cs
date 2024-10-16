using BibliotecaBasis.Aplicacao.Comandos.Assuntos.Validacao;

namespace BibliotecaBasis.Aplicacao.Comandos.Assuntos.Commands
{
    public class AdicionarAssuntoCommand : AssuntoCommand
    {
        public AdicionarAssuntoCommand(string? descricao)
        {
            Descricao = descricao;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarAssuntoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarAssuntoCommandValidation : AssuntoValidation<AdicionarAssuntoCommand>
        {
            public AdicionarAssuntoCommandValidation()
            {
                ValidateDescricao();
            }
        }
    }
}
