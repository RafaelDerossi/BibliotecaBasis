using BibliotecaBasis.Comum.ObjetosDeDominio;
using System.Linq.Expressions;

namespace BibliotecaBasis.Comum.ObjetosDeInfra
{
    public interface IRepository<TEntity> : IDisposable where TEntity : IAggregateRoot
    {
        IUnitOfWorks UnitOfWork { get; }

        Task<TEntity?> ObterPorId(Guid Id);

        /// <summary>
        /// Método Genérico para consultas aleatórias com opção de paginação
        /// </summary>
        /// <param name="expressao">Expressão de consulta</param>
        /// <param name="OrderByDesc">[false - Padrão] = Order by Crescente / [True] = Ordernar decrescentemente pela data de cadastro</param>
        /// <param name="quantidade">Quando passado efetua um Take da quantidade de itens selecionada</param>
        /// <param name="pagina">pagina selecionada</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>?> Obter
            (Expression<Func<TEntity, bool>> expressao, bool OrderByDesc = false, int quantidade = 0, int pagina = 1);


        void Adicionar(TEntity entity);

        void Atualizar(TEntity entity);        
    }
}
