using System;
using Microsoft.EntityFrameworkCore;
using GestaoResiduo.Data;
using GestaoResiduo.Services;
using GestaoResiduo.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Adiciona controladores
builder.Services.AddControllers();

// Configuração do banco de dados (Oracle)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DatabaseConnection")));

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção de dependência (Repositories e Services)
builder.Services.AddScoped<IResiduoRepository, ResiduoRepository>();
builder.Services.AddScoped<IResiduoService, ResiduoService>(); // ✅ Ajustado aqui

var app = builder.Build();

// Configuração do ambiente
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
