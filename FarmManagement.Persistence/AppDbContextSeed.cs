using FarmManagement.Domain.Entitites;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace FarmManagement.Persistence
{
    public class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext context, ILoggerFactory loggerFactory, IConfiguration config)
        {
            try
            {
                if (!context.Provinces.Any())
                {
                    var provinceData = File.ReadAllText($"{config["Seed:Path"]}/Provinces.json");
                    var provinces = JsonSerializer.Deserialize<List<Province>>(provinceData);
                    context.Provinces.AddRange(provinces);
                    await context.SaveChangesAsync();
                }

                if (!context.Cities.Any())
                {
                    var cityData = File.ReadAllText($"{config["Seed:Path"]}/Cities.json");
                    var cities = JsonSerializer.Deserialize<List<City>>(cityData);
                    context.Cities.AddRange(cities);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<AppDbContext>();
                logger.LogError(ex.Message);
            }
        }
    }
}
