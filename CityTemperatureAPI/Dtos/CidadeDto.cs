using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityTemperatureAPI.Dtos
{
    public class CidadeDto
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public decimal TempAtual { get; set; }
        public decimal TempMax { get; set; }
        public decimal TempMin { get; set; }
        public DateTime LastConsult { get; set; }
    }
}
