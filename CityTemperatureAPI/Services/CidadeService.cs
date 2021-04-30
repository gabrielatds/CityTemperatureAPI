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
            if (cidade != null)
            {
                try
                {
                    var cidadeModel = _mapper.Map<CidadeDto, Cidade>(cidade);
                    cidadeModel.LastConsult = DateTime.Now;
                    return await _repository.Add(cidadeModel);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task<bool> CheckIfExists(string name)
        {
            try
            {
                return await _repository.CheckIfExists(name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CidadeDto> GetByName(string nome)
        {
            if(nome.Length > 0 && await CheckIfExists(nome))
            {
                try
                {
                    var cidadeModel = await _repository.GetByName(nome);
                    var cidadeDto = _mapper.Map<Cidade, CidadeDto>(cidadeModel);
                    return cidadeDto;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task<int> Update(CidadeDto cidade)
        {
            if (cidade != null && await CheckIfExists(cidade.Nome))
            {
                try
                {
                    var cidadeModel = _mapper.Map<CidadeDto, Cidade>(cidade);
                    cidadeModel.LastConsult = DateTime.Now;
                    return await _repository.Update(cidadeModel);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task<bool> VerifyLastConsult(CidadeDto cidade)
        {
            if(cidade != null && await CheckIfExists(cidade.Nome))
            {
                var cidadeModel = await _repository.GetByName(cidade.Nome);
                if(DateTime.Now.Minute - cidadeModel.LastConsult.Minute > 20)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
