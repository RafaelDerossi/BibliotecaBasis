using BibliotecaBasis.Comum.ObjetosDeInfra;
using BibliotecaBasis.Dominio.Entidades;
using BibliotecaBasis.Dominio.Interfaces;
using BibliotecaBasis.Dominio.Models.Livros;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BibliotecaBasis.Infra.Data.Repositorio
{
    public class LivroRepositorio(BibliotecaContextDB context) : ILivroRepositorio
    {
        private readonly BibliotecaContextDB _context = context;

        public IUnitOfWorks UnitOfWork => _context;


        public async Task<Livro?> ObterPorId(Guid Id)
        {
            return await _context.Livros?
                .Include(l => l.Autores)
                .Include(l => l.Assuntos)
                .Include(l => l.Precos)
                .FirstOrDefaultAsync(l => l.Id == Id && !l.Lixeira)!;
        }
       
        public async Task<IEnumerable<Livro>?> Obter(Expression<Func<Livro, bool>> expressao, bool OrderByDesc = false, int quantidade = 0, int pagina = 1)
        {
            if (OrderByDesc)
            {
                if (quantidade > 0)
                    return await _context.Livros?
                        .Include(c => c.Autores)
                        .Include(c => c.Assuntos)
                        .Include(l => l.Precos)
                        .Where(expressao)
                        .OrderByDescending(x => x.DataDeCadastro)
                        .Skip((pagina - 1) * quantidade)
                        .Take(quantidade)
                        .ToListAsync()!;

                return await _context.Livros?
                    .Include(c => c.Autores)
                    .Include(c => c.Assuntos)
                    .Include(l => l.Precos)
                    .Where(expressao)
                    .OrderByDescending(x => x.DataDeCadastro)
                    .ToListAsync()!;
            }

            if (quantidade > 0)
                return await _context.Livros?
                    .Include(c => c.Autores)
                    .Include(c => c.Assuntos)
                    .Include(l => l.Precos)
                    .Where(expressao)
                    .OrderBy(x => x.DataDeCadastro)
                    .Skip((pagina - 1) * quantidade)
                    .Take(quantidade)
                    .ToListAsync()!;

            return await _context.Livros?
                .Include(c => c.Autores)
                .Include(c => c.Assuntos)
                .Include(l => l.Precos)
                .Where(expressao)
                .OrderBy(x => x.DataDeCadastro)
                .ToListAsync()!;
        }


        public async Task<IEnumerable<LivroViewModel>?> ObterViewDeLivros()
        {
            return await _context.LivrosCompletosViewModel?                
                .Where(l => !l.Lixeira).ToListAsync()!;
        }


        public void Adicionar(Livro entity)
        {
            _context.Livros?.Add(entity);
        }

        public void Atualizar(Livro entity)
        {
            _context.Livros?.Update(entity);
        }

        



        public async Task<Preco?> ObterPrecoPorId(Guid Id)
        {
            return await _context.Precos?                
                .FirstOrDefaultAsync(l => l.Id == Id && !l.Lixeira)!;
        }


        public void Adicionar(Preco entity)
        {
            _context.Precos?.Add(entity);
        }

        public void Atualizar(Preco entity)
        {
            _context.Precos?.Update(entity);
        }





        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
