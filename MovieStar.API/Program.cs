using MovieStar.API.Configurations;
using MovieStar.Infra.Ioc;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// - Serviços de documentação da API com Swagger
builder.Services.AddSwaggerConfiguration();
// - Inversão de Controle
builder.Services.AddMovieStarInfra(builder.Configuration);

var app = builder.Build();

// - Configuração da aplicação
app.AddApplicationConfiguration();

app.Run();
