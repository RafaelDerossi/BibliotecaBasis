using BibliotecaBasis.Comum.ObjetosDeInfra;
using BibliotecaBasis.Dominio.Entidades;
using BibliotecaBasis.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BibliotecaBasis.Infra.Data.Repositorio
{
    public class LivroRepositorio(LivroContextDB context) : ILivroRepositorio
    {
        private readonly LivroContextDB _context = context;

        public IUnitOfWorks UnitOfWork => _context;


        public async Task<Livro?> ObterPorId(Guid Id)
        {
            return await _context.Livros?
                .Include(c => c.Autores)
                .Include(c => c.Assuntos)
                .FirstOrDefaultAsync(u => u.Id == Id && !u.Lixeira)!;
        }
       
        public async Task<IEnumerable<Livro>?> Obter(Expression<Func<Livro, bool>> expressao, bool OrderByDesc = false, int quantidade = 0, int pagina = 1)
        {
            if (OrderByDesc)
            {
                if (quantidade > 0)
                    return await _context.Livros?
                        .Include(c => c.Autores)
                        .Include(c => c.Assuntos)
                        .AsNoTracking()
                        .Where(expressao)
                        .OrderByDescending(x => x.DataDeCadastro)
                        .Skip((pagina - 1) * quantidade)
                        .Take(quantidade)
                        .ToListAsync()!;

                return await _context.Livros?
                    .Include(c => c.Autores)
                    .Include(c => c.Assuntos)
                    .AsNoTracking()
                    .Where(expressao)
                    .OrderByDescending(x => x.DataDeCadastro)
                    .ToListAsync()!;
            }

            if (quantidade > 0)
                return await _context.Livros?
                    .Include(c => c.Autores)
                    .Include(c => c.Assuntos)
                    .AsNoTracking()
                    .Where(expressao)
                    .OrderBy(x => x.DataDeCadastro)
                    .Skip((pagina - 1) * quantidade)
                    .Take(quantidade)
                    .ToListAsync()!;

            return await _context.Livros?
                .Include(c => c.Autores)
                .Include(c => c.Assuntos)
                .AsNoTracking()
                .Where(expressao)
                .OrderBy(x => x.DataDeCadastro)
                .ToListAsync()!;
        }

       

        public void Adicionar(Livro entity)
        {
            _context.Livros?.Add(entity);
        }

        public void Atualizar(Livro entity)
        {
            _context.Livros?.Update(entity);
        }
           

        

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
