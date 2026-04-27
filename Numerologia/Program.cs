using Microsoft.EntityFrameworkCore;
using Numerologia.Data;
using Numerologia.Repositorio;
using Numerologia.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NumerologiaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IInterpretacionRepositorio, InterpretacionRepositorio>();
builder.Services.AddScoped<IServicioPersona, ServicioPersona>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
