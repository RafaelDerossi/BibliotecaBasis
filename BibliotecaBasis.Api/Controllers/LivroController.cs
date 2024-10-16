using BibliotecaBasis.Api.Controllers.Comum;
using BibliotecaBasis.Aplicacao.Comandos.Livros.Commands;
using BibliotecaBasis.Aplicacao.Consultas.Assuntos;
using BibliotecaBasis.Aplicacao.Consultas.Livros;
using BibliotecaBasis.Comum.Mediator;
using BibliotecaBasis.Dominio.Entidades;
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
        public async Task<ActionResult<IEnumerable<Livro>>> ListarLivros()
        {
            return RespostaPersonalizadaSucesso(await _livroQuery.ObterTodos() ?? []);
        }

        /// <summary>
        /// Adicionar Livro
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AdicionaProduto(AdicionaLivroViewModel viewModel)
        {
            if (!ModelState.IsValid) return RespostaPersonalizadaComValidacao(ModelState);

            var command = new AdicionarLivroCommand(viewModel);

            return RespostaPersonalizadaComValidacao(await _mediatorHandler.EnviarComando(command));
        }
    }

}
