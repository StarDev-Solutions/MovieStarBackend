using MovieStar.API.Configurations;
using MovieStar.Infra.Ioc;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// - Servi�os de documenta��o da API com Swagger
builder.Services.AddSwaggerConfiguration();
// - Invers�o de Controle
builder.Services.AddMovieStarInfra(builder.Configuration);

var app = builder.Build();

// - Configura��o da aplica��o
app.AddApplicationConfiguration();

app.Run();
