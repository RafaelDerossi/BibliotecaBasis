using BibliotecaBasis.Comum.ObjetosDeInfra;
using FluentValidation.Results;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

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
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlException)
                {
                    AdicionarErro
                        ($"Houve um erro ao persistir os dados, " +
                         $"possível violação de restrições (chave primária, chave estrangeira, unique index), " +
                         $"{sqlException.Number} - {sqlException.Message}");
                    return ValidationResult;
                }

                AdicionarErro($"Houve um erro ao persistir os dados, {ex.Message}");
                return ValidationResult;

            }
            catch (SqlException ex)
            {
                AdicionarErro($"Houve um erro ao persistir os dados, " +
                             $"possível problema de conexão com o banco de dados. " +
                             $"{ex.Number} - {ex.Message}");                  
            }
            catch (TimeoutException ex)
            {
                AdicionarErro($"Houve um erro ao persistir os dados, 'Timeout', banco de dados não respondeu. {ex.Message}");
            }
            catch (DBConcurrencyException ex)
            {
                AdicionarErro($"Houve um erro ao persistir os dados, registro alterado simultaneamente. {ex.Message}");
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