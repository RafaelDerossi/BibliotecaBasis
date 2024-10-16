using BibliotecaBasis.Comum.Mediator;
using BibliotecaBasis.Comum.Mensagens;
using BibliotecaBasis.Comum.ObjetosDeInfra;
using BibliotecaBasis.Dominio.Entidades;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaBasis.Infra.Data
{
    public class LivroContextDB : ContextBase, IUnitOfWorks
    {
        public DbSet<Livro>? Livros { get; set; }
        public DbSet<Assunto>? Assuntos { get; set; }
        public DbSet<Autor>? Autores { get; set; }
        
        public LivroContextDB(DbContextOptions<LivroContextDB> options,
                  IMediatorHandler mediatorHandler)
            : base(options, mediatorHandler)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LivroContextDB).Assembly);
        }

    }
}
