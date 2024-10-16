using BibliotecaBasis.Aplicacao.Comandos.Livros.Commands;
using BibliotecaBasis.Comum.Mediator;
using BibliotecaBasis.Dominio.Interfaces;
using BibliotecaBasis.Infra.Data.Repositorio;

namespace BibliotecaBasis.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterDI(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<AdicionarLivroCommand>();                
            });

            services.AddScoped<IMediatorHandler, MediatorHandler>();
            


            services.AddScoped<ILivroRepositorio, LivroRepositorio>();                     
        }
    }
}