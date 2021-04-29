using CityTemperatureAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityTemperatureAPI.Repositories.Interfaces
{
    public interface ICidadeRepository
    {
        Task<Cidade> GetyName(string nome);
        Task<int> Add(Cidade cidade);
        Task<int> Update(Cidade cidade);
        Task<bool> CheckIfExists(int id);
    }
}
