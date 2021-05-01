using CityTemperatureAPI.Repositories;
using CityTemperatureAPI.Repositories.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InfraestructureServiceCollectionExtensions
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection AddInfraestructure(
            this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<ICidadeRepository, CidadeRepository>();

            return services;
        }
    }
}