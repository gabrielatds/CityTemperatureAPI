using AutoMapper;
using CityTemperatureAPI.Dtos;
using CityTemperatureAPI.Models;
using CityTemperatureAPI.Repositories.Interfaces;
using CityTemperatureAPI.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using Xunit;
using System.Threading.Tasks;

namespace CityTemperatureAPI.Tests
{
    public class CidadeServiceTests
    {
        private readonly CidadeService cidadeService;
        private readonly Mock<IMapper> mapper;

        public CidadeServiceTests()
        {
            cidadeService = new CidadeService(new Mock<ICidadeRepository>().Object, new Mock<IMapper>().Object, new Mock<IConfiguration>().Object);
        }

        public static CidadeDto GenerateCidadeDto()
        {
            return new CidadeDto
            {
                Nome = "Teste",
                LastConsult = DateTime.Now,
                TempAtual = 200,
                TempMax = 200,
                TempMin = 200,
            };
        }

        public static Cidade GenerateCidadeModel()
        {
            return new Cidade
            {
                Id = 1,
                LastConsult = DateTime.Now,
                TempAtual = 200,
                TempMax = 200,
                TempMin = 200,
            };
        }

        [Fact]
        public async Task Add_NomeNulo()
        {
            var cidadeDto = GenerateCidadeDto();
            cidadeDto.Nome = null;

            await Assert.ThrowsAnyAsync<ArgumentNullException>(async () =>
            {
                await cidadeService.Add(cidadeDto);
            });
        }


        [Fact]
        public async Task CheckIfExsists_NomeNulo()
        {

            await Assert.ThrowsAnyAsync<ArgumentNullException>(async () =>
            {
                await cidadeService.CheckIfExists(null);
            });
        }

        [Fact]
        public async Task Update_NomeNulo()
        {
            var cidadeDto = GenerateCidadeDto();
            cidadeDto.Nome = null;

            await Assert.ThrowsAnyAsync<ArgumentNullException>(async () =>
            {
                await cidadeService.Add(cidadeDto);
            });
        }
    }
}
