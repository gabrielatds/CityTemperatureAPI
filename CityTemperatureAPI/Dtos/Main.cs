using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityTemperatureAPI.Dtos
{
    public class Main
    {
        [JsonProperty("temp")]
        public decimal Temp { get; set; }
        [JsonProperty("temp_min")]
        public decimal Temp_Min { get; set; }
        [JsonProperty("temp_max")]
        public decimal Temp_Max { get; set; }
    }
}
