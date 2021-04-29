using AutoMapper;
using CityTemperatureAPI.Dtos;
using CityTemperatureAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityTemperatureAPI.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cidade, CidadeDto>();
            CreateMap<CidadeDto, Cidade>();
        }
    }
}
