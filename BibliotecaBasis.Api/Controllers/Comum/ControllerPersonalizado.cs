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
            var errors = new List<string>();

            foreach (var erro in modelState.Values.SelectMany(e => e.Errors))
            {
                errors.Add(erro.ErrorMessage);
            }

            return RespostaPersonalizadaComErros(errors);
        }

        protected ActionResult RespostaPersonalizadaComValidacao(ValidationResult validationResult)
        {
            var errors = new List<string>();

            foreach (var erro in validationResult.Errors)
            {
                errors.Add(erro.ErrorMessage); 
            }            

            return RespostaPersonalizadaComErros(errors);
        }
                
    }
}