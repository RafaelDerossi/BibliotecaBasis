using BibliotecaBasis.Aplicacao.Comandos.Assuntos.Validacao;
using BibliotecaBasis.Dominio.ViewModels.Assuntos;

namespace BibliotecaBasis.Aplicacao.Comandos.Assuntos.Commands
{
    public class AtualizarAssuntoCommand : AssuntoCommand
    {
        public AtualizarAssuntoCommand(AtualizaAssuntoViewModel viewModel)
        {
            Id = viewModel.Id;
            Descricao = viewModel.Descricao;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtualizarAssuntoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtualizarAssuntoCommandValidation : AssuntoValidation<AtualizarAssuntoCommand>
        {
            public AtualizarAssuntoCommandValidation()
            {
                ValidateId();
                ValidateDescricao();
            }
        }
    }
}
