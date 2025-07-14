using Microsoft.EntityFrameworkCore;
using WorldCitiesAPI.Models;

namespace WorldCitiesAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WorldCity> WorldCities { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Här kan du lägga till ytterligare konfigurationer om det behövs
            // t.ex. för att explicit sätta primärnyckel eller index
            modelBuilder.Entity<WorldCity>()
                .HasKey(c => c.CityId);
        }
    }
}