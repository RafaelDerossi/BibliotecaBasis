using BibliotecaBasis.Api.Controllers.Comum;
using BibliotecaBasis.Aplicacao.Comandos.Autores.Commands;
using BibliotecaBasis.Aplicacao.Consultas.Autores;
using BibliotecaBasis.Comum.Mediator;
using BibliotecaBasis.Dominio.ViewModels.Assuntos;
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
        /// Obter Autor
        /// </summary>        
        [HttpGet("{id:Guid}", Name = "ObterAutor")]
        public async Task<ActionResult<AutorComLivrosViewModel>> ObterAutor(Guid id)
        {
            var autor = await _autorQuery.ObterPorId(id);

            if (autor is null)
                return RespostaPersonalizadaComMensagemDeErro("Autor não encontrado");

            return RespostaPersonalizadaSucesso(AutorComLivrosViewModel.Mapear(autor));
        }


        /// <summary>
        /// Obter todos os autores cadastrados
        /// </summary>        
        [HttpGet(Name = "ListarAutores")]
        public async Task<ActionResult<IEnumerable<AutorViewModel>>> ListarAutores()
        {
            var autores = await _autorQuery.ObterTodos() ?? [];

            return RespostaPersonalizadaSucesso(autores.Select(AutorViewModel.Mapear));
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


        /// <summary>
        /// Atualizar Autor
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPut(Name = "AtualizarAutor")]
        public async Task<ActionResult> AtualizarAutor(AtualizaAutorViewModel viewModel)
        {
            if (!ModelState.IsValid) return RespostaPersonalizadaComValidacao(ModelState);

            var command = new AtualizarAutorCommand(viewModel);

            return RespostaPersonalizadaComValidacao(await _mediatorHandler.EnviarComando(command));
        }


        /// <summary>
        /// Apagar Autor
        /// </summary>
        /// <param name="id">Guid</param>
        /// <returns></returns>
        [HttpDelete("{id:Guid}", Name = "ApagarAutor")]
        public async Task<ActionResult> ApagarAutor(Guid id)
        {
            if (!ModelState.IsValid) return RespostaPersonalizadaComValidacao(ModelState);

            var command = new ApagarAutorCommand(id);

            return RespostaPersonalizadaComValidacao(await _mediatorHandler.EnviarComando(command));
        }

    }

}
