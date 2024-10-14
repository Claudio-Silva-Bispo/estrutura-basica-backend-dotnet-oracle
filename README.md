# Projeto Challenge OdontoPrev

## Criar o projeto
```bash
    dotnet new console -n MeuNovoProjeto
```

## Navegue até o diretório do projeto
```bash
    cd MeuNovoProjeto
```

## Execute o projeto para garantir que tudo está funcionando
```bash
    dotnet run
```

## Criar estrutura de pastas

**Criar um arquivo com script**
```bash
    CriarEstruturaPastas.sh
```
**Popular o arquivo com**
```bash
    #!/bin/bash

    # Define o diretório raiz do seu projeto
    rootDir="caminho_da_pasta_aqui"

    # Define a estrutura de pastas
    folders=(
        "$rootDir/src/Domain/Entities"
        "$rootDir/src/Domain/ValueObjects"
        "$rootDir/src/Domain/Interfaces"
        "$rootDir/src/Domain/Services"
        "$rootDir/src/Domain/Exceptions"
        "$rootDir/src/Application/Interfaces"
        "$rootDir/src/Application/Services"
        "$rootDir/src/Application/Commands"
        "$rootDir/src/Application/Queries"
        "$rootDir/src/Application/DTOs"
        "$rootDir/src/Infrastructure/Data/Context"
        "$rootDir/src/Infrastructure/Data/Migrations"
        "$rootDir/src/Infrastructure/Data/Repositories"
        "$rootDir/src/Infrastructure/Services"
        "$rootDir/src/Infrastructure/Email"
        "$rootDir/src/Presentation/Controllers"
        "$rootDir/src/Presentation/ViewModels"
        "$rootDir/src/Presentation/Middlewares"
    )

    # Cria as pastas
    for folder in "${folders[@]}"; do
        mkdir -p "$folder"
    done

    echo "Estrutura de pastas criada com sucesso!"
```

**Executar o comando**
```bash
    chmod +x CriarEstruturaPastas.sh
```

**Executar o comando**
```bash
    ./CriarEstruturaPastas.sh
```

***Isso vai criar as pastas modelos que precisamos para rodar o projeto.***

## Instalar o Pacote Oracle
```bash
    dotnet add package Oracle.ManagedDataAccess
```

## Criar os json com acessos
```bash
    {
    
    "ConnectionStrings": {
        "OracleDbConnection": "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=RM123456;Password=123456;"
    },
    
    "Logging": {
        "LogLevel": {
        "Default": "Information",
        "Microsoft.AspNetCore": "Warning"
            }
        }
    }
``` 

## Instalar demais pacotes
```bash
    dotnet add package Microsoft.EntityFrameworkCore --version 8.0.8
```

```bash
    dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.8
```

```bash
    dotnet add package Swashbuckle.AspNetCore --version 6.4.0
```

```bash
    dotnet add package Swashbuckle.AspNetCore.Annotations --version 6.8.1
```

```bash
    dotnet add package Oracle.EntityFrameworkCore --version 8.23.50
```

```bash
    dotnet add package Oracle.ManagedDataAccess.Core --version 23.6.0
```

## Pasta Infrastructure/Data/Context

**Criar arquivo com contexto**
```bash
    ApplicationContext.cs
```

**Inserir os dados para cada base**
******
```bash
    using ProjetoOdontoPrev.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    namespace ProjetoOdontoPrev.src.Infrastructure.Data.Context
    {
        public class ApplicationContext : DbContext
        {
            public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
            {

            }

            # Inserir as tabelas
            public DbSet<CadastroClienteEntity> Cliente { get; set; }
        
        }
    }
```

## Realizar o teste com o postman

**Ajuste no arquivo Program.cs**

```bash
    
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using ProjetoOdontoPrev.src.Infrastructure.Data.Context;

    var builder = WebApplication.CreateBuilder(args);

    // Adicionar a rota do documento com as configurações do Oracle. Configuração do appsettings.Development.json
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

```

## Realizar o teste

**Criar um Controller Test**
```bash
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using ProjetoOdontoPrev.src.Infrastructure.Data.Context;

    namespace ProjetoOdontoPrev.Presentation.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class TestController : ControllerBase
        {
            private readonly ApplicationContext _context;
            private readonly ILogger<TestController> _logger;

            public TestController(ApplicationContext context, ILogger<TestController> logger)
            {
                _context = context;
                _logger = logger;
            }

            [HttpGet("test-connection")]
            public IActionResult TestConnection()
            {
                try
                {
                    var canConnect = _context.Database.CanConnect();
                    if (canConnect)
                    {
                        return Ok("Conexão com o banco de dados Oracle bem-sucedida!");
                    }
                    else
                    {
                        return StatusCode(500, "Não foi possível conectar ao banco de dados Oracle.");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao conectar ao banco de dados Oracle");
                    return StatusCode(500, $"Erro ao conectar ao banco de dados Oracle: {ex.Message}");
                }
            }
        }
    }
```

**No terminal**
```bash
    dotnet run
```
**No Postaman**
```bash
    http://localhost:5000/api/test/test-connection
```
