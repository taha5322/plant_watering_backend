using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;


namespace watering_api.Models
{
    public class WeatherForecastContext : DbContext
    {
        public WeatherForecastContext(DbContextOptions<WeatherForecastContext> options)
            : base(options)
        {

        }

        public DbSet<Plant> WeatherForecast { get; set; } = null!;
    }
}
