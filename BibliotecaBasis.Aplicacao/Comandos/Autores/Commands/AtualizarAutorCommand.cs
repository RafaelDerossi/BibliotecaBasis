using BibliotecaBasis.Aplicacao.Comandos.Autores.Validacao;
using BibliotecaBasis.Dominio.Models.Autores;

namespace BibliotecaBasis.Aplicacao.Comandos.Autores.Commands
{
    public class AtualizarAutorCommand : AutorCommand
    {
        public AtualizarAutorCommand(AtualizaAutorRequestModel viewModel)
        {
            Id = viewModel.Id;
            Nome = viewModel.Nome;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtualizarAutorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtualizarAutorCommandValidation : AutorValidation<AtualizarAutorCommand>
        {
            public AtualizarAutorCommandValidation()
            {
                ValidateId();
                ValidateNome();
            }
        }
    }
}
