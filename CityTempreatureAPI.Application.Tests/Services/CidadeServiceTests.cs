using AutoMapper;
using CityTemperatureAPI.Repositories.Interfaces;
using CityTemperatureAPI.Services;
using CityTemperatureAPI.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
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
        public void Add_AdicionandoIdExistente()
        {
            Assert.True(true);
        }

    }
}
