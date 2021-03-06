using System;

namespace CityTemperatureAPI.Models
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal TempAtual { get; set; }
        public decimal TempMax { get; set; }
        public decimal TempMin { get; set; }
        public DateTime LastConsult { get; set; }
    }
}
