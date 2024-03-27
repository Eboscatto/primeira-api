using Microsoft.EntityFrameworkCore;
using ControleTarefas.Data;
using Microsoft.Extensions.Options;
using ControleTarefas.Repositorios.Interfaces;
using ControleTarefas.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkSqlServer()
       .AddDbContext<ControleTarefasDBContex>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database"))            
        );

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>(); //Injeção de dependência
builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>(); //Injeção de dependência

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
