using BibliotecaBasis.Api.Configuration;


var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterDI();

Startup startup = new(builder);

startup.RegisterServices
    (builder.Services,
    "API BibliotecaBasis",
    "Esta API é responsável pelo gerenciamento livros");


WebApplication app = builder.Build();

startup.SetupConfigure(app, app.Environment);

app.Run();
