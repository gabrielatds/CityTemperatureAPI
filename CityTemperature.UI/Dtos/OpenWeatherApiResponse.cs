using Newtonsoft.Json;

namespace CityTemperatureAPI.Dtos
{
    public class OpenWeatherApiResponse
    {
        [JsonProperty("main")]
        public Main Main { get; set; }
    }
}
