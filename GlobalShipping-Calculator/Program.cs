using GlobalShipping.Core.Interfaces;
using GlobalShipping.Infrastructure.Data;
using GlobalShipping.Services.Services;
using GlobalShipping.Services.Strategies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Base de datos
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositorios y Servicios de Negocio
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IShippingService, ShippingService>();

// Registro manual de estrategias para el motor de calculo (Open/Closed)
builder.Services.AddScoped<IShippingStrategy, IndiaShippingStrategy>();
builder.Services.AddScoped<IShippingStrategy, UsShippingStrategy>();
builder.Services.AddScoped<IShippingStrategy, UkShippingStrategy>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();