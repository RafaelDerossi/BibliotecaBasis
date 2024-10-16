using BibliotecaBasis.Aplicacao.Comandos.Autores.Validacao;

namespace BibliotecaBasis.Aplicacao.Comandos.Autores.Commands
{
    public class AdicionarAutorCommand : AutorCommand
    {
        public AdicionarAutorCommand(string? nome)
        {
            Nome = nome;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarAutorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarAutorCommandValidation : AutorValidation<AdicionarAutorCommand>
        {
            public AdicionarAutorCommandValidation()
            {
                ValidateNome();
            }
        }
    }
}
