using AutoMapper;
using CityTemperatureAPI.Adapters;
using CityTemperatureAPI.Dtos;
using CityTemperatureAPI.Models;
using CityTemperatureAPI.Repositories.Interfaces;
using CityTemperatureAPI.Services.Interfaces;
using Refit;
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

        public async Task<Main> GetByName(string nome)
        {
            if (!string.IsNullOrEmpty(nome))
            {
                if (await VerifyLastConsult(nome))
                {
                    var cidadeAdapter = RestService.For<ICidadeAdapter>("http://api.openweathermap.org/data/2.5");
                    var response = await cidadeAdapter.GetByName(nome);
                    var mainTemperatures = response.Main;

                    if (mainTemperatures != null)
                    {
                        var cidadeDto = new CidadeDto
                        {
                            Nome = nome,
                            TempAtual = mainTemperatures.Temp,
                            TempMax = mainTemperatures.Temp_Max,
                            TempMin = mainTemperatures.Temp_Min,
                        };

                        if (await CheckIfExists(nome))
                        {
                            await Update(cidadeDto);
                            return mainTemperatures;
                        }
                        else
                        {
                            await Add(cidadeDto);
                            return mainTemperatures;
                        }
                    }
                    else
                    {
                        throw new ArgumentNullException();
                    }
                }
                else
                {
                    var cidadeModel = await _repository.GetByName(nome);
                    var mainTemperatures = new Main
                    {
                        Temp = cidadeModel.TempAtual,
                        Temp_Max = cidadeModel.TempMax,
                        Temp_Min = cidadeModel.TempMin,
                    };
                    return mainTemperatures;
                }

            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task<int> Update(CidadeDto cidade)
        {

            try
            {
                var cidadeModel = await _repository.GetByName(cidade.Nome);
                cidadeModel.LastConsult = DateTime.Now;
                return await _repository.Update(cidadeModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> VerifyLastConsult(string nome)
        {
            if (!string.IsNullOrEmpty(nome))
            {
                if (await CheckIfExists(nome))
                {
                    var cidadeModel = await _repository.GetByName(nome);
                    if (DateTime.Now.Minute - cidadeModel.LastConsult.Minute > 20)
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
                    return true;
                }

            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
