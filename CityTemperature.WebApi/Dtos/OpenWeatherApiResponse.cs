using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityTemperatureAPI.Dtos
{
    public class OpenWeatherApiResponse
    {
        [JsonProperty("main")]
        public Main Main { get; set; }
    }
}
