using BibliotecaBasis.Comum.ObjetosDeInfra;
using FluentValidation.Results;

namespace BibliotecaBasis.Comum.Mediator.Mensagens
{
    public class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected async Task<ValidationResult> PersistirDados(IUnitOfWorks uow)
        {
            try
            {
                if (!await uow.Commit()) AdicionarErro("Houve um erro ao persistir os dados");
            }
            catch (Exception ex)
            {
                AdicionarErro(ex.Message);
            }

            return ValidationResult;
        }

        protected void AdicionarErro(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected void AdicionarErro(ValidationResult validationResult)
        {
            foreach (var item in validationResult.Errors)
            {
                ValidationResult.Errors.Add(new ValidationFailure(string.Empty, item.ErrorMessage));
            }
        }

        protected void LimparErros()
        {
            ValidationResult.Errors.Clear();
        }
    }
}