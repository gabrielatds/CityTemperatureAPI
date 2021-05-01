using AutoMapper;
using CityTemperatureAPI.Adapters;
using CityTemperatureAPI.Dtos;
using CityTemperatureAPI.Models;
using CityTemperatureAPI.Repositories.Interfaces;
using CityTemperatureAPI.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Refit;
using System;
using System.Threading.Tasks;

namespace CityTemperatureAPI.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public CidadeService(ICidadeRepository repository, IMapper mapper, IConfiguration config)
        {
            _cidadeRepository = repository;
            _mapper = mapper;
            _config = config;
        }
        public async Task<int> Add(CidadeDto cidadeDto)
        {
            if (cidadeDto != null && cidadeDto.Nome != null)
            {
                if(await CheckIfExists(cidadeDto.Nome))
                {
                    throw new ArgumentException();
                }
                else
                {
                    try
                    {
                        var cidadeModel = _mapper.Map<CidadeDto, Cidade>(cidadeDto);
                        cidadeModel.LastConsult = DateTime.Now;

                        return await _cidadeRepository.Add(cidadeModel);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task<bool> CheckIfExists(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                try
                {
                    var result = await _cidadeRepository.CheckIfExists(name);
                    return result;
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

        public async Task<Main> GetByName(string nome)
        {
            if (!string.IsNullOrEmpty(nome))
            {
                if (await VerifyLastConsult(nome))
                {
                    var baseUrl = _config.GetValue<string>("ApplicationConfiguration:OpenWeatherApiBaseUrl");
                    var cidadeAdapter = RestService.For<ICidadeAdapter>(baseUrl);
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
                    var cidadeModel = await _cidadeRepository.GetByName(nome);
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

        public async Task<int> Update(CidadeDto cidadeDto)
        {
            if (cidadeDto != null && cidadeDto.Nome != null)
            {
                if (await CheckIfExists(cidadeDto.Nome))
                {
                    try
                    {
                        var cidadeModel = await _cidadeRepository.GetByName(cidadeDto.Nome);
                        cidadeModel.LastConsult = DateTime.Now;
                        return await _cidadeRepository.Update(cidadeModel);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task<bool> VerifyLastConsult(string nome)
        {
            if (!string.IsNullOrEmpty(nome))
            {
                if (await CheckIfExists(nome))
                {
                    var cidadeModel = await _cidadeRepository.GetByName(nome);
                    var nowDate = DateTime.Now;
                    var lastConsultDate = cidadeModel.LastConsult;
                    var timeSpanDifference = nowDate - lastConsultDate;
                    var totalMinuts = timeSpanDifference.TotalMinutes;

                    if (totalMinuts >= 20)
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
