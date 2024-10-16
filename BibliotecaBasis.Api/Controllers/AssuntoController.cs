using BibliotecaBasis.Api.Controllers.Comum;
using BibliotecaBasis.Aplicacao.Comandos.Assuntos.Commands;
using BibliotecaBasis.Aplicacao.Comandos.Autores.Commands;
using BibliotecaBasis.Aplicacao.Consultas.Assuntos;
using BibliotecaBasis.Comum.Mediator;
using BibliotecaBasis.Dominio.ViewModels.Assuntos;
using BibliotecaBasis.Dominio.ViewModels.Livros;
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
        public async Task<ActionResult<AssuntoComLivrosViewModel>> ObterAssunto(Guid id)
        {
            var assunto = await _assuntoQuery.ObterPorId(id);

            if (assunto is null)
                return RespostaPersonalizadaComMensagemDeErro("Assunto n�o encontrado");

            return RespostaPersonalizadaSucesso(AssuntoComLivrosViewModel.Mapear(assunto));
        }

        /// <summary>
        /// Obter todos os assuntos cadastrados
        /// </summary>        
        [HttpGet(Name = "ListarAssuntos")]
        public async Task<ActionResult<IEnumerable<AssuntoViewModel>>> ListarAssuntos()
        {
            var assuntos = await _assuntoQuery.ObterTodos() ?? [];

            return RespostaPersonalizadaSucesso(assuntos.Select(AssuntoViewModel.Mapear));
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

        /// <summary>
        /// Atualizar Assunto
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPut(Name = "AtualizarAssunto")]
        public async Task<ActionResult> AtualizarAssunto(AtualizaAssuntoViewModel viewModel)
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
