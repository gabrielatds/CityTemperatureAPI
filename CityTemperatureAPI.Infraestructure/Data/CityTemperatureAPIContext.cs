using CityTemperatureAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CityTemperatureAPI
{
    public class CityTemperatureAPIContext : DbContext
    {
        public DbSet<Cidade> Cidades { get; set; }

        public CityTemperatureAPIContext(DbContextOptions<CityTemperatureAPIContext> opcoes) : base(opcoes)
        {
        }
    }
}
