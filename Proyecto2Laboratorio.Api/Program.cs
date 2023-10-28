using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Proyecto2Laboratorio.BLL.Implementaciones;
using Proyecto2Laboratorio.BLL.Interfaces;
using Proyecto2Laboratorio.DAL;
using Proyecto2Laboratorio.DAL.Repositorio.Implementaciones;
using Proyecto2Laboratorio.DAL.Repositorio.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddControllers().AddJsonOptions(x =>
//   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

builder.Services.AddDbContext<ApplicationDbContext>( opciones => opciones.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));

//RepositoriosServices
builder.Services.AddScoped<ITurnoRepositorio, TurnoRepositorio>();
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IReciboRepositorio, ReciboRepositorio>();
builder.Services.AddScoped<IPruebaDeLaboratorioRepositorio, PruebaDeLaboratorioRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

//BLLServices
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IReciboService, ReciboService>();
builder.Services.AddScoped<ITurnoService, TurnoService>();
builder.Services.AddScoped<IPruebasLabService, PruebaLabService>();
builder.Services.AddScoped<IMedicoService, MedicoService>();



builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => policy
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
       );
});

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
