using CityTemperatureAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityTemperatureAPI.Repositories.Interfaces
{
    public interface ICidadeRepository
    {
        Task<Cidade> GetByName(string nome);
        Task<int> Add(Cidade cidade);
        Task<int> Update(Cidade cidade);
        Task<bool> CheckIfExists(string nome);
    }
}
