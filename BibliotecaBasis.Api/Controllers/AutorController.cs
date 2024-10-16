using BibliotecaBasis.Api.Controllers.Comum;
using BibliotecaBasis.Aplicacao.Comandos.Autores.Commands;
using BibliotecaBasis.Aplicacao.Consultas.Autores;
using BibliotecaBasis.Comum.Mediator;
using BibliotecaBasis.Dominio.ViewModels.Autores;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaBasis.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutorController
        (ILogger<AutorController> logger, IAutorQuery autorQuery, IMediatorHandler mediatorHandler) : ControllerPersonalizado
    {        
        private readonly ILogger<AutorController> _logger = logger;
        private readonly IMediatorHandler _mediatorHandler = mediatorHandler;

        private readonly IAutorQuery _autorQuery = autorQuery;

        /// <summary>
        /// Obter todos os autores cadastrados
        /// </summary>        
        [HttpGet(Name = "ListarAutores")]
        public async Task<ActionResult<IEnumerable<AutorViewModel>>> ListarAutores()
        {
            return RespostaPersonalizadaSucesso(await _autorQuery.ObterTodos() ?? []);
        }

        /// <summary>
        /// Adicionar Autor
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost(Name = "AdicionarAutor")]
        public async Task<ActionResult> AdicionarAutor(AdicionaAutorViewModel viewModel)
        {
            if (!ModelState.IsValid) return RespostaPersonalizadaComValidacao(ModelState);

            var command = new AdicionarAutorCommand(viewModel.Nome);

            return RespostaPersonalizadaComValidacao(await _mediatorHandler.EnviarComando(command));
        }
    }

}
