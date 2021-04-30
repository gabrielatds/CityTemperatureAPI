using CityTemperatureAPI.Dtos;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityTemperatureAPI.Adapters
{
    public interface ICidadeAdapter
    {
        [Get("/weather?q={nome}&APPID=08747a996d78d3b53f05481d16a707d2")]
        Task<OpenWeatherApiResponse> GetByName(string nome);
    }
}
