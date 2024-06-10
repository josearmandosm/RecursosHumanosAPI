using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RecursosHumanosAPI;
using RecursosHumanosAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar el DbContext y agregarlo como un servicio
builder.Services.AddDbContext<RecursosHumanosDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RecursosHumanosDB")));

// Configurar AutoMapper
builder.Services.AddAutoMapper(typeof(Startup));

// Agregar otros servicios necesarios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
