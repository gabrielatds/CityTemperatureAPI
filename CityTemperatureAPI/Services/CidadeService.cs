using AutoMapper;
using CityTemperatureAPI.Dtos;
using CityTemperatureAPI.Models;
using CityTemperatureAPI.Repositories.Interfaces;
using CityTemperatureAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityTemperatureAPI.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeRepository _repository;
        private readonly IMapper _mapper;

        public CidadeService(ICidadeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> Add(CidadeDto cidade)
        {
            if(cidade != null)
            {
                var cidadeModel = _mapper.Map<CidadeDto, Cidade>(cidade);
                return await _repository.Add(cidadeModel);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public async Task<bool> CheckIfExists(int id)
        {
            return await _repository.CheckIfExists(id);
        }

        public async Task<CidadeDto> GetyName(string nome)
        {
            var cidadeModel = await _repository.GetyName(nome);
            var cidadeDto = _mapper.Map<Cidade, CidadeDto>(cidadeModel);
            return cidadeDto;
        }

        public async Task<int> Update(CidadeDto cidade)
        {
            var cidadeModel = _mapper.Map<CidadeDto, Cidade>(cidade);
            return await _repository.Update(cidadeModel);
        }

        public async Task<int> VerifyLastConsult(CidadeDto cidade)
        {
            throw new NotImplementedException();
        }
    }
}
