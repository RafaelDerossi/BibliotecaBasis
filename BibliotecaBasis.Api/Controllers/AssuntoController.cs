using BibliotecaBasis.Api.Controllers.Comum;
using BibliotecaBasis.Aplicacao.Comandos.Assuntos.Commands;
using BibliotecaBasis.Aplicacao.Consultas.Assuntos;
using BibliotecaBasis.Comum.Mediator;
using BibliotecaBasis.Dominio.ViewModels.Assuntos;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaBasis.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssuntoController
        (ILogger<AssuntoController> logger, IAssuntoQuery assuntoQuery, IMediatorHandler mediatorHandler) : ControllerPersonalizado
    {        
        private readonly ILogger<AssuntoController> _logger = logger;
        private readonly IMediatorHandler _mediatorHandler = mediatorHandler;

        private readonly IAssuntoQuery _assuntoQuery = assuntoQuery;

        /// <summary>
        /// Obter todos os assuntos cadastrados
        /// </summary>        
        [HttpGet(Name = "ListarAssuntos")]
        public async Task<ActionResult<IEnumerable<AssuntoViewModel>>> ListarAssuntos()
        {
            return RespostaPersonalizadaSucesso(await _assuntoQuery.ObterTodos() ?? []);
        }

        /// <summary>
        /// Adicionar Assunto
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost(Name = "AdicionarAssunto")]
        public async Task<ActionResult> AdicionarAssunto(AdicionaAssuntoViewModel viewModel)
        {
            if (!ModelState.IsValid) return RespostaPersonalizadaComValidacao(ModelState);

            var command = new AdicionarAssuntoCommand(viewModel.Descricao);

            return RespostaPersonalizadaComValidacao(await _mediatorHandler.EnviarComando(command));
        }
    }

}
