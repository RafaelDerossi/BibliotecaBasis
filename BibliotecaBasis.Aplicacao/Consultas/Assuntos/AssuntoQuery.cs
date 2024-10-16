using BibliotecaBasis.Dominio.Interfaces;
using BibliotecaBasis.Dominio.Entidades;

namespace BibliotecaBasis.Aplicacao.Consultas.Assuntos
{
    public class AssuntoQuery(IAssuntoRepositorio assuntoRepositorio) : IAssuntoQuery
    {
        private readonly IAssuntoRepositorio _assuntoRepositorio = assuntoRepositorio;

        public async Task<Assunto?> ObterPorId(Guid Id)
        {
            return await _assuntoRepositorio.ObterPorId(Id);
        }

        public async Task<IEnumerable<Assunto>?> ObterTodos()
        {
            return await _assuntoRepositorio.Obter(l => !l.Lixeira);
        }



        public void Dispose()
        {
            _assuntoRepositorio.Dispose();
        }
    }
}
