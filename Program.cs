using ExaParcial_SandovalRamos.Middleware;

var builder = WebApplication.CreateBuilder(args);

/// <summary>
/// AGREGAR CONTROLADORES
/// </summary>
builder.Services.AddControllers();

/// <summary>
/// CONFIGURACIÓN DE SWAGGER
/// </summary>
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/// <summary>
/// MIDDLEWARE PARA MANEJO DE EXCEPCIONES
/// </summary>
app.UseMiddleware<MiddlewareExcepciones>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

/// <summary>
/// MAPEAR CONTROLADORES
/// </summary>
app.MapControllers();

app.Run();