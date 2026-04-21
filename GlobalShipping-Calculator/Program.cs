using GlobalShipping.Core.Interfaces;
using GlobalShipping.Infrastructure.Data;
using GlobalShipping.Services.Services;
using GlobalShipping.Services.Strategies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configurar Entity Framework Core con SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inyección de Dependencias: Registro de Repositorio y Servicio Principal
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IShippingService, ShippingService>();

// Inyección de Dependencias: Registro del Patrón Strategy (Se inyectan como colección de IEnumerable<IShippingStrategy>)
builder.Services.AddScoped<IShippingStrategy, IndiaShippingStrategy>();
builder.Services.AddScoped<IShippingStrategy, UsShippingStrategy>();
builder.Services.AddScoped<IShippingStrategy, UkShippingStrategy>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
