using CityTemperatureAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityTemperatureAPI.Services.Interfaces
{
    public interface ICidadeService
    {
        Task<Main> GetByName(string nome);
        Task<int> Add(CidadeDto cidade);
        Task<int> Update(CidadeDto cidade);
        Task<bool> VerifyLastConsult(CidadeDto cidade);
        Task<bool> CheckIfExists(string nome);
    }
}
