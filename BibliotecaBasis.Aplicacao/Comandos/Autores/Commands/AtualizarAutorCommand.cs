using BibliotecaBasis.Aplicacao.Comandos.Autores.Validacao;
using BibliotecaBasis.Dominio.ViewModels.Autores;

namespace BibliotecaBasis.Aplicacao.Comandos.Autores.Commands
{
    public class AtualizarAutorCommand : AutorCommand
    {
        public AtualizarAutorCommand(AtualizaAutorViewModel viewModel)
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
