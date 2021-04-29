using CityTemperatureAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
