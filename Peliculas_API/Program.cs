using Microsoft.EntityFrameworkCore;
using Peliculas.Application.Interfaces;
using Peliculas.Application.Services;
using Peliculas.Infrastructure.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//area  de servicios
builder.Services.AddControllers().AddJsonOptions(opciones =>
opciones.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opciones =>
opciones.UseSqlServer("name=DefaultConnection"));

builder.Services.AddScoped<IDirectorBLL, DirectorServicesBLL>();
builder.Services.AddScoped<IMoviesBLL, MoviesServiceBLL>();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
            .WithOrigins(
            "http://localhost")
            .AllowCredentials()
            .AllowAnyHeader()
            .SetIsOriginAllowed(_ => true)
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
