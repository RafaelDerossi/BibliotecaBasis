namespace BibliotecaBasis.Api.Configuration
{
    public class Startup
    {
        public Startup(WebApplicationBuilder builder)
        {
            builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (builder.Environment.IsDevelopment())
            {
                builder.Configuration.AddUserSecrets<Startup>();
            }

            builder.Configuration.SetBasePath(builder.Environment.ContentRootPath);

            Configuration = builder.Configuration;
        }


        public ConfigurationManager Configuration { get; }

        public void RegisterServices
            (IServiceCollection services, string apiTitle, string apiDescription)
        {

            services.AddApiConfiguration();

            services.AddSwaggerConfiguration(apiTitle, apiDescription);

            services.AddControllers();
            
            services.AddEndpointsApiExplorer();            

            services.AddHealthChecks();
        }

        public void SetupConfigure(WebApplication app, IWebHostEnvironment env)
        {            
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }            

            app.UseSwaggerConfiguration();

            app.UseApiConfiguration(env);

            app.UseHttpsRedirection();
           
            app.MapHealthChecks("/healthcheck").AllowAnonymous();
        }
    }

}