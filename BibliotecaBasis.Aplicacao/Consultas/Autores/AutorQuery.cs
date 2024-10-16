using BibliotecaBasis.Dominio.Interfaces;
using BibliotecaBasis.Dominio.Entidades;

namespace BibliotecaBasis.Aplicacao.Consultas.Autores
{
    public class AutorQuery(IAutorRepositorio autorRepositorio) : IAutorQuery
    {
        private readonly IAutorRepositorio _autorRepositorio = autorRepositorio;

        public async Task<Autor?> ObterPorId(Guid Id)
        {
            return await _autorRepositorio.ObterPorId(Id);
        }

        public async Task<IEnumerable<Autor>?> ObterTodos()
        {
            return await _autorRepositorio.Obter(l => !l.Lixeira);
        }



        public void Dispose()
        {
            _autorRepositorio.Dispose();
        }
    }
}
