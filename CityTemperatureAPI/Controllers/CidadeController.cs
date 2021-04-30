using CityTemperatureAPI.Adapters;
using CityTemperatureAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityTemperatureAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : ControllerBase
    {
        private readonly ICidadeService _service;

        public CidadeController(ICidadeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetByName(string nome)
        {
            try
            {
                var cidadeAdapter = RestService.For<ICidadeAdapter>("http://api.openweathermap.org/data/2.5");
                var cidadeDto = await cidadeAdapter.GetByName(nome);



                return Ok(cidadeDto.Main);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
