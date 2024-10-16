using BibliotecaBasis.Api.Controllers.Comum;
using BibliotecaBasis.Aplicacao.Comandos.Assuntos.Commands;
using BibliotecaBasis.Aplicacao.Consultas.Assuntos;
using BibliotecaBasis.Comum.Mediator;
using BibliotecaBasis.Dominio.Models.Assuntos;
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
        /// Obter assunto
        /// </summary>        
        [HttpGet("{id:Guid}", Name = "ObterAssunto")]
        public async Task<ActionResult<AssuntoComLivrosResponseModel>> ObterAssunto(Guid id)
        {
            var assunto = await _assuntoQuery.ObterPorId(id);

            if (assunto is null)
                return RespostaPersonalizadaComMensagemDeErro("Assunto não encontrado");

            return RespostaPersonalizadaSucesso(AssuntoComLivrosResponseModel.Mapear(assunto));
        }

        /// <summary>
        /// Obter todos os assuntos cadastrados
        /// </summary>        
        [HttpGet(Name = "ListarAssuntos")]
        public async Task<ActionResult<IEnumerable<AssuntoResponseModel>>> ListarAssuntos()
        {
            var assuntos = await _assuntoQuery.ObterTodos() ?? [];

            return RespostaPersonalizadaSucesso(assuntos.Select(AssuntoResponseModel.Mapear));
        }

        /// <summary>
        /// Adicionar Assunto
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost(Name = "AdicionarAssunto")]
        public async Task<ActionResult> AdicionarAssunto(AdicionaAssuntoRequestModel viewModel)
        {
            if (!ModelState.IsValid) return RespostaPersonalizadaComValidacao(ModelState);

            var command = new AdicionarAssuntoCommand(viewModel.Descricao);

            return RespostaPersonalizadaComValidacao(await _mediatorHandler.EnviarComando(command));
        }

        /// <summary>
        /// Atualizar Assunto
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPut(Name = "AtualizarAssunto")]
        public async Task<ActionResult> AtualizarAssunto(AtualizaAssuntoRequestModel viewModel)
        {
            if (!ModelState.IsValid) return RespostaPersonalizadaComValidacao(ModelState);

            var command = new AtualizarAssuntoCommand(viewModel);

            return RespostaPersonalizadaComValidacao(await _mediatorHandler.EnviarComando(command));
        }


        /// <summary>
        /// Apagar Assunto
        /// </summary>
        /// <param name="id">Guid</param>
        /// <returns></returns>
        [HttpDelete("{id:Guid}", Name = "ApagarAssunto")]
        public async Task<ActionResult> ApagarAssunto(Guid id)
        {
            if (!ModelState.IsValid) return RespostaPersonalizadaComValidacao(ModelState);

            var command = new ApagarAssuntoCommand(id);

            return RespostaPersonalizadaComValidacao(await _mediatorHandler.EnviarComando(command));
        }
    }

}
