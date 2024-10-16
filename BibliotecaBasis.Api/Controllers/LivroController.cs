using BibliotecaBasis.Api.Controllers.Comum;
using BibliotecaBasis.Aplicacao.Comandos.Livros.Commands;
using BibliotecaBasis.Aplicacao.Consultas.Livros;
using BibliotecaBasis.Comum.Mediator;
using BibliotecaBasis.Dominio.ViewModels.Livros;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaBasis.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController
        (ILogger<LivroController> logger, ILivroQuery livroQuery, IMediatorHandler mediatorHandler) : ControllerPersonalizado
    {        
        private readonly ILogger<LivroController> _logger = logger;
        private readonly IMediatorHandler _mediatorHandler = mediatorHandler;

        private readonly ILivroQuery _livroQuery = livroQuery;

        /// <summary>
        /// Obter todos os livros cadastrados
        /// </summary>        
        [HttpGet(Name = "ListarLivros")]
        public async Task<ActionResult<IEnumerable<LivroViewModel>>> ListarLivros()
        {
            var livros = await _livroQuery.ObterTodos() ?? [];

            return RespostaPersonalizadaSucesso(livros.Select(LivroViewModel.Mapear));
        }


        /// <summary>
        /// Adicionar Livro
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost(Name = "AdicionarLivro")]
        public async Task<ActionResult> AdicionarLivro(AdicionaLivroViewModel viewModel)
        {
            if (!ModelState.IsValid) return RespostaPersonalizadaComValidacao(ModelState);

            var command = new AdicionarLivroCommand(viewModel);

            return RespostaPersonalizadaComValidacao(await _mediatorHandler.EnviarComando(command));
        }


        /// <summary>
        /// Atualizar Livro
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPut(Name = "AtualizarLivro")]
        public async Task<ActionResult> AtualizarLivro(AtualizaLivroViewModel viewModel)
        {
            if (!ModelState.IsValid) return RespostaPersonalizadaComValidacao(ModelState);

            var command = new AtualizarLivroCommand(viewModel);

            return RespostaPersonalizadaComValidacao(await _mediatorHandler.EnviarComando(command));
        }


        /// <summary>
        /// Apagar Livro
        /// </summary>
        /// <param name="id">Guid</param>
        /// <returns></returns>
        [HttpDelete("{id:Guid}", Name = "ApagarLivro")]
        public async Task<ActionResult> ApagarLivro(Guid id)
        {
            if (!ModelState.IsValid) return RespostaPersonalizadaComValidacao(ModelState);

            var command = new ApagarLivroCommand(id);

            return RespostaPersonalizadaComValidacao(await _mediatorHandler.EnviarComando(command));
        }
    }

}
