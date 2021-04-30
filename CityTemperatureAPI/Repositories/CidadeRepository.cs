using CityTemperatureAPI.Models;
using CityTemperatureAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityTemperatureAPI.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly CityTemperatureAPIContext _context;
        public CidadeRepository(CityTemperatureAPIContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Cidade cidade)
        {
            _context.Cidades.Add(cidade);
            return await _context.SaveChangesAsync();
        }

        public async Task<Cidade> GetByName(string nome)
        {
            return await _context.Cidades.Where(a => a.Nome == nome).FirstOrDefaultAsync();
        }

        public async Task<int> Update(Cidade cidade)
        {
            _context.Cidades.Update(cidade);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckIfExists(string nome)
        {
            return await _context.Cidades.AnyAsync(a => a.Nome == nome);
        }
    }
}
