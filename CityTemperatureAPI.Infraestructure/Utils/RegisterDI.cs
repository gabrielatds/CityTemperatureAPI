using CityTemperatureAPI.Repositories;
using CityTemperatureAPI.Repositories.Interfaces;
using CityTemperatureAPI.Services;
using CityTemperatureAPI.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CityTemperatureAPI.Infraestructure.Utils
{
    public static class RegisterDI
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<ICidadeService, CidadeService>();
        }
    }
}
