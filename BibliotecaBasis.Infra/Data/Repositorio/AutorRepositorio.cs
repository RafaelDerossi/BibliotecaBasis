using BibliotecaBasis.Comum.ObjetosDeInfra;
using BibliotecaBasis.Dominio.Entidades;
using BibliotecaBasis.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BibliotecaBasis.Infra.Data.Repositorio
{
    public class AutorRepositorio(BibliotecaContextDB context) : IAutorRepositorio
    {
        private readonly BibliotecaContextDB _context = context;

        public IUnitOfWorks UnitOfWork => _context;


        public async Task<Autor?> ObterPorId(Guid Id)
        {
            return await _context.Autores?
                .Include(l => l.Livros)                
                .FirstOrDefaultAsync(l => l.Id == Id && !l.Lixeira)!;
        }
       
        public async Task<IEnumerable<Autor>?> Obter(Expression<Func<Autor, bool>> expressao, bool OrderByDesc = false, int quantidade = 0, int pagina = 1)
        {
            if (OrderByDesc)
            {
                if (quantidade > 0)
                    return await _context.Autores?                        
                        .AsNoTracking()
                        .Where(expressao)
                        .OrderByDescending(x => x.DataDeCadastro)
                        .Skip((pagina - 1) * quantidade)
                        .Take(quantidade)
                        .ToListAsync()!;

                return await _context.Autores?                
                    .AsNoTracking()
                    .Where(expressao)
                    .OrderByDescending(x => x.DataDeCadastro)
                    .ToListAsync()!;
            }

            if (quantidade > 0)
                return await _context.Autores?                
                    .AsNoTracking()
                    .Where(expressao)
                    .OrderBy(x => x.DataDeCadastro)
                    .Skip((pagina - 1) * quantidade)
                    .Take(quantidade)
                    .ToListAsync()!;

            return await _context.Autores?            
                .AsNoTracking()
                .Where(expressao)
                .OrderBy(x => x.DataDeCadastro)
                .ToListAsync()!;
        }

       

        public void Adicionar(Autor entity)
        {
            _context.Autores?.Add(entity);
        }

        public void Atualizar(Autor entity)
        {
            _context.Autores?.Update(entity);
        }
           

        

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
