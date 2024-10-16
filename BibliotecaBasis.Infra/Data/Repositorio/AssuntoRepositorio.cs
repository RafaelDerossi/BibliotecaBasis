using BibliotecaBasis.Comum.ObjetosDeInfra;
using BibliotecaBasis.Dominio.Entidades;
using BibliotecaBasis.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BibliotecaBasis.Infra.Data.Repositorio
{
    public class AssuntoRepositorio(BibliotecaContextDB context) : IAssuntoRepositorio
    {
        private readonly BibliotecaContextDB _context = context;

        public IUnitOfWorks UnitOfWork => _context;


        public async Task<Assunto?> ObterPorId(Guid Id)
        {
            return await _context.Assuntos?
                .Include(l => l.Livros)                
                .FirstOrDefaultAsync(l => l.Id == Id && !l.Lixeira)!;
        }
       
        public async Task<IEnumerable<Assunto>?> Obter(Expression<Func<Assunto, bool>> expressao, bool OrderByDesc = false, int quantidade = 0, int pagina = 1)
        {
            if (OrderByDesc)
            {
                if (quantidade > 0)
                    return await _context.Assuntos?
                        .Where(expressao)
                        .OrderByDescending(x => x.DataDeCadastro)
                        .Skip((pagina - 1) * quantidade)
                        .Take(quantidade)
                        .ToListAsync()!;

                return await _context.Assuntos?
                    .Where(expressao)
                    .OrderByDescending(x => x.DataDeCadastro)
                    .ToListAsync()!;
            }

            if (quantidade > 0)
                return await _context.Assuntos?
                    .Where(expressao)
                    .OrderBy(x => x.DataDeCadastro)
                    .Skip((pagina - 1) * quantidade)
                    .Take(quantidade)
                    .ToListAsync()!;

            return await _context.Assuntos?
                .Where(expressao)
                .OrderBy(x => x.DataDeCadastro)
                .ToListAsync()!;
        }

       

        public void Adicionar(Assunto entity)
        {
            _context.Assuntos?.Add(entity);
        }

        public void Atualizar(Assunto entity)
        {
            _context.Assuntos?.Update(entity);
        }
           

        

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
