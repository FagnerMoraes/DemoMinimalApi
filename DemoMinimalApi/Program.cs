using DemoMinimalApi.Data;
using DemoMinimalApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MinimalContextDb>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/fornecedores", async (
    MinimalContextDb context) => 
    await context.Fornecedores.ToListAsync())
    .WithName("GetFornecedores")
    .WithTags("Fornecedor");

app.MapGet("/fornecedores/{id}", async (
    Guid id, 
    MinimalContextDb context) =>

    await context.Fornecedores.FindAsync(id)
        is Fornecedor fornecedor
        ? Results.Ok(fornecedor)
        : Results.NotFound())
    .WithName("GetFornecedoresPorId")
    .WithTags("Fornecedor");

app.Run();
