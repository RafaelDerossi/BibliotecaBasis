using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BibliotecaBasis.Api.Controllers.Comum
{
    [ApiController]
    public abstract class ControllerPersonalizado : ControllerBase
    {
        protected ActionResult RespostaPersonalizadaVaziaSucesso()
        {
            return Ok(new
            {
                success = true
            });
        }

        protected ActionResult RespostaPersonalizadaSucesso(object? dados)
        {
            if (dados == null)
                return NoContent();

            return Ok(new
            {
                success = true,
                data = dados
            });
        }

        protected ActionResult RespostaPersonalizadaComMensagemDeErro(string erro)
        {
            return BadRequest(new
            {
                success = false,
                errors = new List<string> { erro }
            });
        }

        protected ActionResult RespostaPersonalizadaComErros(List<string> erros)
        {
            return BadRequest(new
            {
                success = false,
                errors = erros.ToArray()
            });
        }

        protected ActionResult RespostaPersonalizadaComValidacao(ModelStateDictionary modelState)
        {
            var modelErros = modelState.Values.SelectMany(e => e.Errors);

            if (modelErros != null && modelErros.Count() > 0)
            {
                var errors = new List<string>();

                foreach (var erro in modelState.Values.SelectMany(e => e.Errors))
                {
                    errors.Add(erro.ErrorMessage);
                }

                return RespostaPersonalizadaComErros(errors);
            }

            return RespostaPersonalizadaVaziaSucesso();
        }

        protected ActionResult RespostaPersonalizadaComValidacao(ValidationResult validationResult)
        {
            if (validationResult.Errors.Count() > 0)
            {
                var errors = new List<string>();

                foreach (var erro in validationResult.Errors)
                {
                    errors.Add(erro.ErrorMessage);
                }

                return RespostaPersonalizadaComErros(errors);
            }

            return RespostaPersonalizadaVaziaSucesso();
        }
                
    }
}