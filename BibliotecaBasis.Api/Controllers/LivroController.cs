using BibliotecaBasis.Api.Controllers.Comum;
using BibliotecaBasis.Aplicacao.Comandos.Livros.Commands;
using BibliotecaBasis.Aplicacao.Consultas.Livros;
using BibliotecaBasis.Comum.Enumeradores;
using BibliotecaBasis.Comum.Mediator;
using BibliotecaBasis.Dominio.Entidades;
using BibliotecaBasis.Dominio.ViewModels.Autores;
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
        /// Obter Livro
        /// </summary>        
        [HttpGet("{id:Guid}", Name = "ObterLivro")]
        public async Task<ActionResult<LivroViewModel>> ObterLivro(Guid id)
        {
            var livro = await _livroQuery.ObterPorId(id);

            if (livro is null)
                return RespostaPersonalizadaComMensagemDeErro("Livro não encontrado");

            return RespostaPersonalizadaSucesso(LivroViewModel.Mapear(livro));
        }


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





        /// <summary>
        /// Adicionar Preco
        /// </summary>
        /// <param name="viewModel">
        ///  LivroId: Guid do livro;    
        ///  Valor: Valor em reais;    
        ///  FormaDeVenda: Enum da forma de venda: (BALCAO = 1, SELF_SERVICE = 2, INTERNET = 3, EVENTO = 4, OUTROS = 5);     
        /// </param>
        /// <returns></returns>
        [HttpPost("preco", Name = "AdicionarPreco")]
        public async Task<ActionResult> AdicionarPreco(AdicionaPrecoViewModel viewModel)
        {
            if (!ModelState.IsValid) return RespostaPersonalizadaComValidacao(ModelState);

            var command = new AdicionarPrecoCommand(viewModel);

            return RespostaPersonalizadaComValidacao(await _mediatorHandler.EnviarComando(command));
        }

        /// <summary>
        /// Apagar Preco
        /// </summary>
        /// <param name="id">Guid</param>
        /// <returns></returns>
        [HttpDelete("preco/{id:Guid}", Name = "ApagarPreco")]
        public async Task<ActionResult> ApagarPreco(Guid id)
        {
            if (!ModelState.IsValid) return RespostaPersonalizadaComValidacao(ModelState);

            var command = new ApagarPrecoCommand(id);

            return RespostaPersonalizadaComValidacao(await _mediatorHandler.EnviarComando(command));
        }

    }

}
