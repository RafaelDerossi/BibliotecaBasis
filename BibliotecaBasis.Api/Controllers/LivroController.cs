using BibliotecaBasis.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaBasis.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {        
        private readonly ILogger<LivroController> _logger;

        public LivroController(ILogger<LivroController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "ListarLivros")]
        public async Task<IEnumerable<Livro>> ListarLivros()
        {
            return new List<Livro>();
        }
    }
}
