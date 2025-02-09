using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Services;
using ToDoList.Domain.Repositories;
using ToDoList.Infrastructure.Data;
using ToDoList.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configura��o do banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registros
builder.Services.AddScoped<TarefaService>();
builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();

// Configura��o do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura��o do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin() // Permite qualquer origem (n�o recomendado para produ��o)
                   .AllowAnyMethod() // Permite qualquer m�todo (GET, POST, etc.)
                   .AllowAnyHeader(); // Permite qualquer cabe�alho
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); // Comente se estiver testando localmente sem HTTPS

// Use CORS
app.UseCors("AllowAllOrigins");

app.UseAuthorization();
app.MapControllers();

app.Run();