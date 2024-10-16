using BibliotecaBasis.Comum.Hepers;
using BibliotecaBasis.Comum.Mediator;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BibliotecaBasis.Comum.ObjetosDeInfra
{
    public abstract class ContextBase : DbContext, IUnitOfWorks
    {
        private readonly IMediatorHandler _mediatorHandler;

        protected ContextBase
            (DbContextOptions options, IMediatorHandler mediatorHandler)
            : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        public async Task<bool> Commit()
        {
            var cetZone = ZonaDeTempo.ObterZonaDeTempo();

            foreach (var entry in ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("DataDeCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataDeCadastro").CurrentValue =
                        TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);
                    entry.Property("DataDeAlteracao").CurrentValue =
                        entry.Property("DataDeCadastro").CurrentValue;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataDeCadastro").IsModified = false;
                    entry.Property("DataDeAlteracao").CurrentValue =
                        TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);
                }
            }
            
            return await SaveChangesAsync() > 0;
        }
    }
}
