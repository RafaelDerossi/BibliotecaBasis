using BibliotecaBasis.Aplicacao.Comandos.Livros.Commands;
using BibliotecaBasis.Aplicacao.Consultas.Assuntos;
using BibliotecaBasis.Aplicacao.Consultas.Autores;
using BibliotecaBasis.Aplicacao.Consultas.Livros;
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


            services.AddScoped<IAssuntoQuery, AssuntoQuery>();
            services.AddScoped<IAutorQuery, AutorQuery>();
            services.AddScoped<ILivroQuery, LivroQuery>();

            services.AddScoped<IAssuntoRepositorio, AssuntoRepositorio>();
            services.AddScoped<IAutorRepositorio, AutorRepositorio>();
            services.AddScoped<ILivroRepositorio, LivroRepositorio>();      
            
        }
    }
}