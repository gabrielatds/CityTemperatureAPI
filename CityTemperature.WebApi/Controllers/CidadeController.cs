using CityTemperatureAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CityTemperatureAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : ControllerBase
    {
        private readonly ICidadeService _cidadeService;

        public CidadeController(ICidadeService cidadeService)
        {
            _cidadeService = cidadeService;
        }

        /// <summary>
        /// Busca a cidade pelo nome e retorna as temperaturas
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetByName(string nome)
        {
            var mainTempreatures = await _cidadeService.GetByName(nome);
            return Ok(mainTempreatures);
        }
    }
}
