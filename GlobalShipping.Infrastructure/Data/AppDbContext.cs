using GlobalShipping.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalShipping.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Country>()
                .Property(c => c.BaseShippingRate).HasColumnType("decimal(18,2)");
            
            modelBuilder.Entity<Country>()
                .Property(c => c.MaxWeight).HasColumnType("decimal(18,2)");

            // Seed Data con limites razonables (India: 50kg, US: 100kg, UK: 70kg)
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "India", Code = "IN", BaseShippingRate = 5.0m, MaxWeight = 50.0m },
                new Country { Id = 2, Name = "Estados Unidos", Code = "US", BaseShippingRate = 8.0m, MaxWeight = 100.0m },
                new Country { Id = 3, Name = "Reino Unido", Code = "UK", BaseShippingRate = 10.0m, MaxWeight = 70.0m }
            );
        }
    }
}