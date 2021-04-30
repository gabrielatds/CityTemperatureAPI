using AutoMapper;
using CityTemperatureAPI.Dtos;
using CityTemperatureAPI.Repositories.Interfaces;
using CityTemperatureAPI.Services;
using CityTemperatureAPI.Services.Interfaces;
using Moq;
using System;
using Xunit;

namespace CityTempreatureAPI.Application.Tests.Services
{
    public class CidadeServiceTests
    {
        private ICidadeService _cidadeService;

        public CidadeServiceTests()
        {
            _cidadeService = new CidadeService(
                new Mock<ICidadeRepository>().Object,
                new Mock<IMapper>().Object);
        }

        [Fact]
        public async void Add_AdicionandoIdExistente()
        {
            await Assert.ThrowsAsync<Exception>(() =>  _cidadeService.Add(new CidadeDto
            {
                Id = 6,
                TempAtual = 200,
                TempMax = 200,
                TempMin = 200,
                Nome = "Belo Horizonte",
            }));
        }

    }
}
