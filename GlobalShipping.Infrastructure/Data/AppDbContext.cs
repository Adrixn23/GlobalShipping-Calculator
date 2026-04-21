using GlobalShipping.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalShipping.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configuraciones de precisión para montos de dinero
            modelBuilder.Entity<Country>()
                .Property(c => c.BaseShippingRate)
                .HasColumnType("decimal(18,2)");

            // Seed Data: Semillas de datos requeridos por las reglas del negocio del caso.
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "India", Code = "IN", BaseShippingRate = 5.0m, IsActive = true },
                new Country { Id = 2, Name = "Estados Unidos", Code = "US", BaseShippingRate = 8.0m, IsActive = true },
                new Country { Id = 3, Name = "Reino Unido", Code = "UK", BaseShippingRate = 10.0m, IsActive = true }
            );
        }
    }
}