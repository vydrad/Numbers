using Microsoft.EntityFrameworkCore;
using Numerologia.Data;
using Numerologia.Repositorio;
using Numerologia.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<NumerologiaDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IInterpretacionRepositorio, InterpretacionRepositorio>();
builder.Services.AddScoped<IServicioPersona, ServicioPersona>();

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
