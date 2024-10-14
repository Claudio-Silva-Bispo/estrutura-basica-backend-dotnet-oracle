
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProjetoOdontoPrev.src.Infrastructure.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Adicionar configuração do appsettings.json
builder.Configuration.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);

//Configurando a string e conexo oracle no banco de dados
builder.Services.AddDbContext<ApplicationContext>(options => {

    // O Oracle vem do arquivo appsettings.Development, da string de conexão.
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDbConnection"));

});


//Adicionando a interface e classe concreta no framework de injeco de dependencia

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//Configurando e habilitando a documentao no swagger 
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Claudio Silva Bispo",
        Version = "RM 553472",
        Description = "API desenvolvida para CP2 de DOTNET, na faculdade FIAP."
    });
    c.EnableAnnotations(); // Habilitar anotaes no Swagger
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

